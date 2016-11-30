using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Dominio.Models;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class TipoPagamentoViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Por favor digite um nome", AllowEmptyStrings = true)]
        public string Nome { get; set; }

        public virtual ICollection<Pagamento> Pagamento { get; set; }

    }
}