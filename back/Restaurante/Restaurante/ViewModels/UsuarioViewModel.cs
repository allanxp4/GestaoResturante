using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels
{
    public class UsuarioViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 4)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        public int TipoId { get; set; }

        public virtual ICollection<Conta> Conta { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }

    }
}