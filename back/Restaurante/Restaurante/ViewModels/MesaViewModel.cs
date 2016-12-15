using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Potatotech.GestaoRestaurante.Dominio.Models;
using System.ComponentModel.DataAnnotations;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class MesaViewModel
    {

        public int Id { get; set; }
        public int Capacidade { get; set; }
        public bool Ocupada { get; set; }
        public int AmbienteId { get; set; }

        public virtual Ambiente Ambiente { get; set; }
        public virtual ICollection<Conta> Conta { get; set; }

        public SelectList AmbienteSelectList { get; set; }

    }
}