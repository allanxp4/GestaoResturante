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
    public class UsuarioController : ApiController
    {
        #region PRIVATE
        private UnitOfWork _unit = new UnitOfWork();
        #endregion PRIVATE

        #region GET
        public ICollection<Usuario> Get()
        {
            return _unit.UsuarioRepository.Listar();
        }
        #endregion GET

        #region POST
        public IHttpActionResult Post(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _unit.UsuarioRepository.Cadastrar(usuario);
                _unit.Salvar();
                return Ok();
            }
            
            return BadRequest(ModelState);
            
        }
        #endregion POST
    }
}
