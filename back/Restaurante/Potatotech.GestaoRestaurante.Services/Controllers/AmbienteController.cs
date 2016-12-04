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
    public class AmbienteController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public ICollection<Ambiente> Get()
        {
            return _unit.AmbienteRepository.Listar();
        }

        public IHttpActionResult Post(Ambiente ambiente)
        {
            _unit.AmbienteRepository.Cadastrar(ambiente);
            return Ok();
        }
    }
}
