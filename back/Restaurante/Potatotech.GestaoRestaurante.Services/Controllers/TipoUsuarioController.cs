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
    public class TipoUsuarioController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public ICollection<TipoUsuario> Get()
        {
            return _unit.TipoUsuarioRepository.Listar();
        }

        public IHttpActionResult Post(TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _unit.TipoUsuarioRepository.Cadastrar(tipoUsuario);
                _unit.Salvar();
                return Ok();
            }
            
            return BadRequest(ModelState);
            
        }
    }
}
