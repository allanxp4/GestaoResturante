using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Dominio.Models;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class TipoUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}