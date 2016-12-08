using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Potatotech.GestaoRestaurante.Dominio.Models;

using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Web.ViewModels;


namespace Potatotech.GestaoRestaurante.Repositories.Controllers
{
    public class GarcomController : Controller
    {

        private UnitOfWork _unit = new UnitOfWork();
        // GET: Garcom
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Pedido");
        }

        [HttpGet]
        public ActionResult Pedido()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult HistoricoPedidos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TabelaPedidos(int pagina)
        {
            if (pagina < 1)
            {
                return HttpNotFound();
            }
            pagina -= 1;
            int PAGE_SIZE = 5;
            //TODO: Retornar direto do banco certo
            List<Pedido> pedidos = _unit.PedidoRepository.Listar().ToList();
            var pedidosPaginados = pedidos.OrderBy(p => p.Id).Skip(PAGE_SIZE * pagina).Take(PAGE_SIZE);
            var pedidosvm = Mapper.Map<List<PedidoViewModel>>(pedidosPaginados);

            if (pedidosvm.Count < 1)
            {
                return HttpNotFound();
            }

            return PartialView("_tabela", pedidosvm);
        }
    }
}