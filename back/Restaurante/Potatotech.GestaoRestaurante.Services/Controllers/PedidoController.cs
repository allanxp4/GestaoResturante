using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class PedidoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public ICollection<Pedido> Get()
        {
            return _unit.PedidoRepository.Listar();
        }

        public Pedido Get(int id)
        {
            return _unit.PedidoRepository.BuscarPorId(id);
        }

        public IHttpActionResult Post(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _unit.PedidoRepository.Cadastrar(pedido);
                _unit.Salvar();
                var uri = Url.Link("DefaultApi", new { id = pedido.Id });
                return Created<Pedido>(new Uri(uri), pedido);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult Put(int id, Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Id = id;
                _unit.PedidoRepository.Alterar(pedido);
                _unit.Salvar();
                return Ok(pedido);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public void Delete(int id)
        {

            _unit.PedidoRepository.Remover(id);
            _unit.Salvar();

        }
    }
}
