using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public partial class PedidoModel
    {
        public int    IdPedido    { get; set; }
        public string Nome   { get; set; }
        public string Sobrenome  { get; set; }
        public string Telefone      { get; set; }
        public string Email      { get; set; }
        public decimal Total     { get; set; }
        public System.DateTime DataVenda      { get; set; }
        public List<PedidoInfoModel> PedidoDetalhes { get; set; }
    }
}