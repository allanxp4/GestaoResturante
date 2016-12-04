using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using AutoMapper;
using Potatotech.GestaoRestaurante.Services.DTOs;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class PedidoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();
        private Conta _conta;

        public ICollection<Pedido> Get()
        {
            return _unit.PedidoRepository.Listar();
        }

        public IHttpActionResult Post(PedidoDto p)
        {
            var pedido = Mapper.Map<Pedido>(p);
            var mesa = _unit.MesaRepository.BuscarPorId(p.Mesa);

            if (!mesa.Ocupada)
            {
                _conta = _unit.ContaRepository.Cadastrar(new Conta()) as Conta;
                _unit.MesaRepository.Alterar(mesa);
                _conta.Pedido.Add(pedido);
                //TODO: terminar essa bagaça
            }
            else
            {
                var contas = _unit.ContaRepository.BuscarPor(c => c.MesaId == mesa.Id && c.Fechada == false);
                if (contas.Count == 1)
                {
                    _conta = contas.First();
                    _conta.Pedido.Add(pedido);
                }
                else
                {
                    return InternalServerError();
                }
            }
            return Ok();
        }
    }
}
