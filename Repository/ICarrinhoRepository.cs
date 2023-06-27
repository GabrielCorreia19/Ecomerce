using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebStore.Models;

namespace WebStore.Repository
{
    public interface ICarrinhoRepository
    {
        public void adicionarItemAoCarrinho(ProdutoModel produto);
        public int removerItemDoCarrinho(int id);
        public void limparCarrinho();
        public List<CarrinhoModel> getListaDeItensDoCarrinho();

        public int CriarPedido(PedidoModel pedido);
        public int getQuantidadeDeItensNoCarrinho();
        public decimal getValorTotalDosItensCarrinho();

        public CarrinhoModel getCarrinho();
    

    }
}