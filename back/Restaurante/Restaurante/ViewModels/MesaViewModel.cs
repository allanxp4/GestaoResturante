using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels
{
    public class MesaViewModel
    {

        public int Id { get; set; }
        public int Capacidade { get; set; }
        public bool Ocupada { get; set; }
        public int AmbienteId { get; set; }

        public virtual Ambiente Ambiente { get; set; }
        public virtual ICollection<Conta> Conta { get; set; }

    }
}