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
        #region PRIVATE
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GET
        public ICollection<TipoUsuario> Get()
        {
            return _unit.TipoUsuarioRepository.Listar();
        }
        #endregion GET

        #region POST
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
        #endregion POST
    }
}
