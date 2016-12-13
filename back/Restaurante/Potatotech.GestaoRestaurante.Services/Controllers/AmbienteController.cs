using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using AutoMapper;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class AmbienteController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        #region GET
        public ICollection<Ambiente> Get()
        {
            return _unit.AmbienteRepository.Listar();
        }

        public Ambiente Get(int id)
        {
            return _unit.AmbienteRepository.BuscarPorId(id);
        }

        #endregion

        #region POST

        public IHttpActionResult Post(Ambiente ambiente)
        {
            if (ModelState.IsValid)
            {
                _unit.AmbienteRepository.Cadastrar(ambiente);
                _unit.Salvar();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #endregion

        #region PUT
        public IHttpActionResult Put(int id, Ambiente ambiente)
        {
            if (ModelState.IsValid)
            {
                var ambienteRaw = Mapper.Map<Ambiente>(ambiente);
                _unit.AmbienteRepository.Alterar(ambienteRaw);
                _unit.Salvar();
                return Ok(ambiente);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        #region DELETE
        public void Delete(int id)
        {
            _unit.AmbienteRepository.Remover(id);
            _unit.Salvar();
        }
        #endregion
    }
}
