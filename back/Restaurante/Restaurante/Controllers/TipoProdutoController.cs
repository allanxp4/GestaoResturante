using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;

namespace Potatotech.GestaoRestaurante.Web.Controllers
{
    public class TipoProdutoController : Controller
    {

        #region PRIVATE

        private UnitOfWork _unit = new UnitOfWork();

        #endregion

        #region GET

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.TipoProdutoRepository.Listar();

            TipoProdutoViewModel tp = new TipoProdutoViewModel()
            {
                TiposProduto = lista
            };

            return View(tp);
        }

        [HttpGet]
        public ActionResult Editar(int idTipoControle)
        {
            var tipoProduto = _unit.TipoProdutoRepository.BuscarPorId(idTipoControle);

            var viewModel = new TipoProdutoViewModel()
            {
                Id = tipoProduto.Id,
                Nome = tipoProduto.Nome
            };

            return PartialView("_editar", viewModel);
        }

        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(TipoProdutoViewModel tp)
        {
            TipoProduto tipoProduto = new TipoProduto()
            {
                Id = tp.Id,
                Nome = tp.Nome
            };

            _unit.TipoProdutoRepository.Cadastrar(tipoProduto);
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Deletar(int tipoProdutoId)
        {
            _unit.TipoProdutoRepository.Remover(tipoProdutoId);
            _unit.Salvar();

            return RedirectToAction("Listar");
        }


        #endregion

        #region DISPOSE

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}