using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Models;
using System.Web;
using WebStore.Controllers;

namespace WebStore.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {

        WebStoreContext storeDB = new WebStoreContext();
        string ShoppingCartId { get; set; }
        int idDoCarrinho {get;set;}
        public const string CartSessionKey = "IdCarrinhoStr";

        

        public static CarrinhoRepository GetCart(HttpContext context)
        {
            var carrinho = new CarrinhoRepository();
            carrinho.ShoppingCartId = carrinho.GetCartId(context);

            return carrinho;
        }

        public static CarrinhoRepository GetCart(HomeController controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void adicionarItemAoCarrinho(ProdutoModel produto)
        {
            var itemCarrinho = storeDB.Carrinhos.SingleOrDefault(
                c => c.IdCarrinhoStr == ShoppingCartId &&
                 c.IdProduto == produto.IdProduto);
            if (itemCarrinho == null)
            {
                itemCarrinho = new CarrinhoModel
                {
                    IdProduto = produto.IdProduto,
                    IdCarrinhoStr = ShoppingCartId,
                    Quantidade = 1,
                    DataCriacao = DateTime.Now
                };
                storeDB.Add(itemCarrinho);
            }
            else
            {
                itemCarrinho.Quantidade++;
            }
            storeDB.SaveChanges();
        }

        public int CriarPedido(PedidoModel pedido)
        {
            decimal totalPedido = 0;
            var itensDoCarrinho = getListaDeItensDoCarrinho();
            foreach (var item in itensDoCarrinho)
            {
                var detalhesPedido = new PedidoInfoModel
                {
                    IdProduto = item.IdProduto,
                    IdPedido = pedido.IdPedido,
                    Preco = item.Produto.Preco,
                    Quantidade = item.Quantidade
                };
                totalPedido += (item.Quantidade * item.Produto.Preco);
                storeDB.PedidoInfos.Add(detalhesPedido);
            }
            pedido.Total = totalPedido;

            storeDB.SaveChanges();
            limparCarrinho();
            return pedido.IdPedido;
        }
        public List<CarrinhoModel> getListaDeItensDoCarrinho()
        {
            return storeDB.Carrinhos.Where(
                c => c.IdCarrinhoStr == ShoppingCartId).ToList();
        }

        public CarrinhoModel getCarrinho()
        {
            throw new NotImplementedException();
        }

        public int getQuantidadeDeItensNoCarrinho()
        {
            int? quantidade = (from itensDoCarrinho in storeDB.Carrinhos
                               where itensDoCarrinho.IdCarrinhoStr == ShoppingCartId
                               select (int?)itensDoCarrinho.Quantidade).Sum();

            return quantidade ?? 0;
        }

        public decimal getValorTotalDosItensCarrinho()
        {
            decimal? total = (from itensDoCarrinho in storeDB.Carrinhos
                              where itensDoCarrinho.IdCarrinhoStr == ShoppingCartId
                              select (int?)itensDoCarrinho.Quantidade * itensDoCarrinho.Produto.Preco).Sum();

            return total ?? 0;
        }

        public void limparCarrinho()
        {
            var itensCarrinho = storeDB.Carrinhos.Where(
                carrinho => carrinho.IdCarrinhoStr == ShoppingCartId);
            foreach (var itemDoCarrinho in itensCarrinho)
            {
                storeDB.Carrinhos.Remove(itemDoCarrinho);
            }
            storeDB.SaveChanges();
        }

        public int removerItemDoCarrinho(int id)
        {
            var itemCarrinho = storeDB.Carrinhos.Single(
                carrinho => carrinho.IdCarrinhoStr == ShoppingCartId &&
                 carrinho.IdCarrinho == id);

            int quantidadeDeItens = 0;

            if (itemCarrinho != null)
            {
                if (itemCarrinho.Quantidade > 1)
                {
                    itemCarrinho.Quantidade--;
                    quantidadeDeItens = itemCarrinho.Quantidade;
                }
                else
                {
                    storeDB.Carrinhos.Remove(itemCarrinho);
                }
                storeDB.SaveChanges();

            }
            return quantidadeDeItens;
        }

        public string GetCartId(HttpContext context)
        {
            if (context.Session.GetString(CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session.SetString(CartSessionKey,context.User.Identity.Name);
                
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session.SetString(CartSessionKey,tempCartId.ToString());
                }
            }
            return context.Session.GetString(CartSessionKey);
        }

        public void MigrarCarrinho(string nome)
        {
            var carrinho = storeDB.Carrinhos.Where(
                c => c.IdCarrinhoStr == ShoppingCartId);
 
            foreach (CarrinhoModel item in carrinho)
            {
                item.IdCarrinhoStr = nome;
            }
            storeDB.SaveChanges();
        }
    }
}