using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;
using WebStore.Repository;
using WebStore.ViewModel;

namespace WebStore.Controllers;

public class CarrinhoController : Controller
{
    WebStoreContext storeDB = new WebStoreContext();

    
    public IActionResult Index()
    {
        var carrinho = CarrinhoRepository.GetCart(this.HttpContext);

        var viewModel = new CarrinhoDeComprasViewModel{
            ItensDoCarrinho = carrinho.getListaDeItensDoCarrinho(),
            TotalDoCarrinho = carrinho.getValorTotalDosItensCarrinho()
        };
        return View(viewModel);
    }

    public IActionResult AdicionarCarrinho(int id)
    {
        // Recupera o produto do banco de dados
        var produtoAdded = storeDB.Produtos.Single(produto => produto.IdProduto == id);
        // Adicionando o produto ao carrinho
        var carrinho = CarrinhoRepository.GetCart(this.HttpContext);
        carrinho.adicionarItemAoCarrinho(produtoAdded);

        return RedirectToAction("Index");
    }
    [HttpPost]
        public ActionResult RemoverCarrinho(int id)
        {
            // Remove the item from the cart
            var carrinho = CarrinhoRepository.GetCart(this.HttpContext);
 
            // Get the name of the album to display confirmation
            string nomeProduto = storeDB.Carrinhos
                .Single(item => item.IdCarrinho == id).Produto.Nome;
 
            // Remove from cart
            int itemCount = carrinho.removerItemDoCarrinho(id);
 
            // Display the confirmation message
            var results = new CarrinhoDeComprasRemoveViewModel
            {
                
                TotalDoCarrinho = carrinho.getValorTotalDosItensCarrinho(),
                CartCount = carrinho.getQuantidadeDeItensNoCarrinho(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        
        public ActionResult CartSummary()
        {
            var cart = CarrinhoRepository.GetCart(this.HttpContext);
 
            ViewData["CartCount"] = cart.getQuantidadeDeItensNoCarrinho();
            return PartialView("CartSummary");
        }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
