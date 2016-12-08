using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Potatotech.GestaoRestaurante.Web.Controllers
{
    public class CaixaController : Controller
    {
        // GET: Caixa
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detalhes()
        {
            return View();
        }
    }
}