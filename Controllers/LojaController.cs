using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;

namespace WebStore.Controllers
{
    public class LojaController : Controller
    {
        WebStoreContext storeDB = new WebStoreContext();

        public ActionResult Index()
        {
            var produtos = storeDB.Produtos.ToList();
            return View(produtos);
        }
        public ActionResult Detalhes(int id)
        {
            var produto = storeDB.Produtos.Find(id);

            return View(produto);
        }
    }
}