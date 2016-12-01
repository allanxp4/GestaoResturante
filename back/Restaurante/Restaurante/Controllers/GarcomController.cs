using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Omu.ValueInjecter;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Web.ViewModels;

namespace Potatotech.GestaoRestaurante.Repositories.Controllers
{
    public class GarcomController : Controller
    {

        private UnitOfWork _unit = new UnitOfWork();
        // GET: Garcom
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pedido()
        {
            return View();
        }

        public ActionResult HistoricoPedidos()
        {
            var pedidos = _unit.PedidoRepository.Listar();
            var pedidosvm = Mapper.Map<>(pedidos);
            return View();
        }
    }
}