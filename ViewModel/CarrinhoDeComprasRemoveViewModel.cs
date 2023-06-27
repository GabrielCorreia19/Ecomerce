using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModel
{
    public class CarrinhoDeComprasRemoveViewModel
    {
        public string Mensagem { get; set; }
        public decimal TotalDoCarrinho { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}