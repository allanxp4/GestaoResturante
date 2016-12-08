using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Potatotech.GestaoRestaurante.Dominio.Models;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class ProdutoViewModel
    {

        public ICollection<Produto> Produtos { get; set; }
        public SelectList ListaTipoProduto { get; set; }

        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        [Display(Name = "Valor Imposto ")]
        public Nullable<decimal> Imposto { get; set; }

        [Display(Name = "Tipo do Produto")]
        public int TipoId { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual TipoProduto TipoProduto { get; set; }

        public string NomeBusca { get; set; }
    }
}