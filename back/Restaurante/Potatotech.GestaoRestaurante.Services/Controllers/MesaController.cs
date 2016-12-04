﻿using System;
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
    }
}
