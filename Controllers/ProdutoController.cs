using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Models;
using WebStore.Repository;

namespace WebStore.Controllers
{
    
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        
        public IActionResult ListagemProduto()
        {
            List<ProdutoModel> produtos = _produtoRepository.listarProdutos();
            return View(produtos);
        }
        
        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepository.buscarId(id);
            return View(produto);
        }


        public IActionResult ConfirmarDelete(int id)
        {
            ProdutoModel produto = _produtoRepository.buscarId(id);
            return View(produto);
        }
        public IActionResult RegistrarProduto()
        {
            return View();
        }
         public IActionResult ProdutoSkylife1()
        {
            return View();
        }
        public IActionResult Deletar(int id)
        {
            _produtoRepository.deletarProduto(id);
            return RedirectToAction("ListagemProduto");
        }


        [HttpPost]
        public IActionResult RegistrarProduto(ProdutoModel produto)
        {
            _produtoRepository.adicionarProduto(produto);
            return RedirectToAction("ListagemProduto");
        }

        [HttpPost]
        public IActionResult Atualizar(ProdutoModel produto)
        {
            _produtoRepository.atualizarProduto(produto);
            return RedirectToAction("ListagemProduto");
        }

    }
}