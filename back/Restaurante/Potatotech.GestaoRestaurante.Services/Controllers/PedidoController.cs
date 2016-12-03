using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Potatotech.GestaoRestaurante.Services.DTOs;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class PedidoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public ICollection<Pedido> Get()
        {
            return _unit.PedidoRepository.Listar();
        }

        public IHttpActionResult Post(PedidoDto pedido)
        {
            var contaId = 0;
            var mesa = _unit.MesaRepository.BuscarPorId(pedido.Mesa);
            if (!mesa.Ocupada)
            {
                //contaId = _unit.ContaRepository.Cadastrar(new Conta());
                mesa.ContaId = contaId;
                _unit.MesaRepository.Alterar(mesa);
                var conta = _unit.ContaRepository.BuscarPorId(mesa.ContaId);
                //TODO: terminar essa bagaça
                

            }
            return InternalServerError();
        }
    }
}
