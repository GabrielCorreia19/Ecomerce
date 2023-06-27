using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class CarrinhoModel
    {
        [Key]
        public int      IdCarrinho    { get; set; }
        public string   IdCarrinhoStr      { get; set; }
        public int      IdProduto     { get; set; }
        public int      Quantidade       { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public virtual ProdutoModel Produto  { get; set; }
    }
}