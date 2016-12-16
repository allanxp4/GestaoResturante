using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
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
            var contasAbertas = _unit.ContaRepository.BuscarPor(x => x.Pago == false);
            var contas = contasAbertas.Where(x => x.MesaId == id).ToList();
            if (contas.Count != 1)
            {
                return HttpNotFound();
            }
            var conta = contas.First();
            conta.Fechada = true;
            _unit.ContaRepository.Alterar(conta);
            _unit.Salvar();
            return View(Mapper.Map<ContaViewModel>(conta));
        }

        #endregion GET

        [HttpGet]
        public ActionResult FecharConta(int id)
        {
            var mesa = id;
            var contasAbertas = _unit.ContaRepository.BuscarPor(x => x.Pago == false);
            var contas = contasAbertas.Where(x => x.MesaId == mesa).ToList();
            if (contas.Count != 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            var conta = contas.First();
            conta.Pago = true;
            _unit.ContaRepository.Alterar(conta);
            _unit.Salvar();
            return RedirectToAction("Index");
        }
    }
}