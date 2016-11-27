using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels
{
    public class TipoUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}