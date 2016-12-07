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

        public ICollection<PedidoDto> Get()
        {
            var listaRaw =_unit.PedidoRepository.Listar();
            return Mapper.Map<ICollection<PedidoDto>>(listaRaw);
        }

        public IHttpActionResult Post(PedidoDto p)
        {
            if (ModelState.IsValid)
            {
                var pedido = Mapper.Map<Pedido>(p);
                pedido.UsuarioId = 1;
                var mesa = _unit.MesaRepository.BuscarPorId(p.MesaId);

                if (!mesa.Ocupada)
                {
                    _conta = new Conta() { MesaId = p.MesaId, UsuarioId = 1 };
                    _unit.ContaRepository.Cadastrar(_conta);
                    _unit.Salvar();
                    _conta.Pedido.Add(pedido);
                    _unit.ContaRepository.Alterar(_conta);
                    _unit.Salvar();
                    //TODO: terminar essa bagaça
                }
                else
                {
                    var contas = _unit.ContaRepository.BuscarPor(c => c.MesaId == mesa.Id && c.Fechada == false);
                    if (contas.Count == 1)
                    {
                        _conta = contas.First();
                        _conta.Pedido.Add(pedido);
                        _unit.ContaRepository.Alterar(_conta);
                    }
                    else
                    {
                        return InternalServerError();
                    }
                }
                
            }
            return Ok();
        }
    }
}
