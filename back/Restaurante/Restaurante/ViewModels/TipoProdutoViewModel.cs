using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Web.Models;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class TipoProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}