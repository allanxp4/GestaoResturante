using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class MesaController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();
        public ICollection<Mesa> Get()
        {
            return _unit.MesaRepository.Listar();
        }

        public IHttpActionResult Post(Mesa mesa)
        {
            Mesa mesa2 = new Mesa()
            {
                AmbienteId = 1,
                Capacidade = 4,
                Ocupada = false
            };
            _unit.MesaRepository.Cadastrar(mesa2);
            return Ok();
        }
    }
}
