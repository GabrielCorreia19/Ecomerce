using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.ViewModel
{
    public class CarrinhoDeComprasViewModel
    {
        public List<CarrinhoModel> ItensDoCarrinho { get; set; }
        public decimal TotalDoCarrinho { get; set; }
    }
}