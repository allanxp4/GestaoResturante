using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using AutoMapper;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Web.ViewModels;

namespace Potatotech.GestaoRestaurante.Web.Controllers
{
   
    [Authorize]
    public class MesaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        // GET: Mesa

        #region GET
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TabelaMesa(int pagina)
        {
            if (pagina < 1)
            {
                return HttpNotFound("Página inválida");
            }
            pagina -= 1;
           
            int TAMANHO_PAGINA = 5;
            var listaraw =
                _unit.MesaRepository.Listar()
                    .ToList()
                    .Skip(pagina*TAMANHO_PAGINA)
                    .Take(TAMANHO_PAGINA);

            return PartialView("_tabela", Mapper.Map<List<MesaViewModel>>(listaraw));
        }

        [HttpGet]
        public ActionResult FormMesa()
        {
            var vm = new MesaViewModel()
            {
                AmbienteSelectList = SelectAmbiente()
            };

            return PartialView("_adicionar", vm);
        }
        #endregion

        #region POST

        [HttpPost]
        public ActionResult Adicionar(MesaViewModel mesaViewModel)
        {
            if (ModelState.IsValid)
            {
                _unit.MesaRepository.Cadastrar(Mapper.Map<Mesa>(mesaViewModel));
                _unit.Salvar();
            }
            return Redirect(Request.UrlReferrer.AbsolutePath);

        }

        #endregion

        #region SELECT
        private SelectList SelectAmbiente()
        {
            var ambientes = _unit.AmbienteRepository.Listar();
            return new SelectList(ambientes, "Id", "Nome");
        }
        #endregion


    }

}