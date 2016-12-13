using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Web.ViewModels;

namespace Potatotech.GestaoRestaurante.Web.Controllers
{
   
    public class CaixaController : Controller
    {
        #region PRIVATE
        public UnitOfWork _unit = new UnitOfWork();
        #endregion PRIVATE
        // GET: Caixa
        #region GET
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

        [HttpGet]
        public ActionResult DetalhesMesa(int id)
        {
            var conta = _unit.ContaRepository.BuscarPor(x => x.MesaId == id);
            if (conta.Count != 1)
            {
                return HttpNotFound();
            }
            
            return View(Mapper.Map<ContaViewModel>(conta.First()));
        }
        #endregion GET
    }
}