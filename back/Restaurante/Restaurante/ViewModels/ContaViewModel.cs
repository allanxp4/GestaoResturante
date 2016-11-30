using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Dominio.Models;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class ContaViewModel
    {

        public int Id { get; set; }
        public int MesaId { get; set; }
        public int UsuarioId { get; set; }

        public decimal Desconto { get; set; }

        public bool Pago { get; set; }
        
        [Display(Name = "Data Pagamento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public Nullable<System.DateTime> DataHoraPagamento { get; set; }

        [Required(ErrorMessage = "Por favor escolha uma mesa")]
        public virtual Mesa Mesa { get; set; }

        [Required(ErrorMessage = "Por favor escolha um usuário")]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Pagamento> Pagamento { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }

}
