using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
namespace WebStore.Models
{
    public class PedidoInfoModel
    {
        public int IdPedidoDetalhe { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public virtual ProdutoModel Produto { get; set; }
        public virtual PedidoModel Pedido { get; set; }
    }
}