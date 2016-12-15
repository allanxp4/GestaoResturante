using Potatotech.GestaoRestaurante.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class RecepcaoViewModel
    {

        public ICollection<Mesa> Mesas { get; set; }

        public int MesaId { get; set; }

        public virtual Mesa Mesa { get; set; }


    }
}