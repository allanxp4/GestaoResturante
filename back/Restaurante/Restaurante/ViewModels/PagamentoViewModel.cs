using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Web.Models;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class PagamentoViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor digite um valor")]
        public decimal Valor { get; set; }

        public int TipoId { get; set; }

        public int ContaId { get; set; }

        [Required(ErrorMessage = "Por favor escolha uma conta")]
        public virtual Conta Conta { get; set; }

        [Required(ErrorMessage = "Por favor escolha um tipo de pagamento")]
        public virtual TipoPagamento TipoPagamento { get; set; }
    }
}