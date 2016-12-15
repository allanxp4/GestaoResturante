using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Services.DTOs;
using AutoMapper;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class MesaController : ApiController
    {
        #region PRIVATE
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GET
        public ICollection<Mesa> Get()
        {
            return _unit.MesaRepository.Listar();
        }
        #endregion

        #region POST
        public IHttpActionResult Post(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                _unit.MesaRepository.Cadastrar(mesa);
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
        public IHttpActionResult Put(int id, MesaDto mesa)
        {
            if (ModelState.IsValid)
            {
                var mesaRaw = Mapper.Map<Mesa>(mesa);
                _unit.MesaRepository.Alterar(mesaRaw);
                _unit.Salvar();
                return Ok(mesa);
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
            _unit.MesaRepository.Remover(id);
            _unit.Salvar();
        }
        #endregion
    }
}
