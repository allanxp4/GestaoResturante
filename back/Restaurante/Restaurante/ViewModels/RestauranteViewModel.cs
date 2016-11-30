using Potatotech.GestaoRestaurante.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Potatotech.GestaoRestaurante.Web.ViewModels
{
    public class RestauranteViewModel
    {
        public int qtdMesas { get; set; }
        public int qtdAmbientes { get; set; }
        public Ambiente ambiente { get; set; }
        public Usuario gerente { get; set; }
    }
}