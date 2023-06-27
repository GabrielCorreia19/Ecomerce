using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
namespace WebStore.Repository
{
    public interface IProdutoRepository
    {
        ProdutoModel adicionarProduto(ProdutoModel prod);
        ProdutoModel buscarId(int id);
        List<ProdutoModel> listarProdutos();
        ProdutoModel atualizarProduto(ProdutoModel prod);

        bool deletarProduto(int id);
    }
}