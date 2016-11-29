using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Web.Models;
using System.Web.Mvc;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class ProdutoViewModel
    {

        public ICollection<Produto> Produtos { get; set; }
        public SelectList ListaTipoProduto { get; set; }

        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Por favor digite um nome", AllowEmptyStrings = true)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor digite um valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Por favor digite um valor")]
        [Display(Name = "Valor Imposto ")]
        public Nullable<decimal> Imposto { get; set; }

        [Required(ErrorMessage = "Por favor seleciona o tipo do produto")]
        [Display(Name = "Tipo do Produto")]
        public int TipoId { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual TipoProduto TipoProduto { get; set; }
    }
}