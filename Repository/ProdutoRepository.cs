using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Models;
namespace WebStore.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly WebStoreContext produto_Context;

        public ProdutoRepository(WebStoreContext produtoContext)
        {  
            this.produto_Context = produtoContext;
        }

        public ProdutoModel adicionarProduto(ProdutoModel produto)
        {
            produto_Context.Produtos.Add(produto);
            produto_Context.SaveChanges();
            return produto;
        }

        public List<ProdutoModel> listarProdutos()
        {
            return produto_Context.Produtos.ToList();
        }
        public ProdutoModel atualizarProduto(ProdutoModel produto)
        {
            ProdutoModel produtoDB = buscarId(produto.IdProduto);

            if(produtoDB == null) throw new Exception("Produto não foi encontrado");

            produtoDB.Nome = produto.Nome;
            produtoDB.Descricao = produto.Descricao;
            produtoDB.Marca = produto.Marca;
            produtoDB.Categoria = produto.Categoria;
            produtoDB.Preco = produto.Preco;
            
            produto_Context.Update(produtoDB);
            produto_Context.SaveChanges();
            return produtoDB;
        }

        public ProdutoModel buscarId(int id)
        {
            return produto_Context.Produtos.FirstOrDefault(x=> x.IdProduto == id);
        }
        

        public bool deletarProduto(int id)
        {
            ProdutoModel produtoDB = buscarId(id);
            if(produtoDB == null) throw new Exception("Produto não foi encontrado");

            produto_Context.Produtos.Remove(produtoDB);
            produto_Context.SaveChanges();
            return true;
        }

    }
}
