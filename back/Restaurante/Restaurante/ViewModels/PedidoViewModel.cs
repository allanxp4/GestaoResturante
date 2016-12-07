using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Dominio.Models;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class PedidoViewModel
    {

        public int Id { get; set; }
        public bool Viagem { get; set; }
   
        [StringLength(250)]
        [Display(Name = "Observações Extras")]
        public string Observacoes { get; set; }

        public int ContaId { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public System.DateTime DataHora { get; set; }

        public int UsuarioId { get; set; }

        public virtual Conta Conta { get; set; }
        public virtual ICollection<PedidosDoProduto> PedidosDoProduto { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}