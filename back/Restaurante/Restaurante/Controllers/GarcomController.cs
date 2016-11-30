using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Potatotech.GestaoRestaurante.Repositories.Controllers
{
    public class GarcomController : Controller
    {
        // GET: Garcom
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pedido()
        {
            return View();
        }
    }
}