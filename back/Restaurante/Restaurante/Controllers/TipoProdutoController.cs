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
    [Authorize]
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
        public ActionResult Editar(int tipoId)
        {
            var tipoProduto = _unit.TipoProdutoRepository.BuscarPorId(tipoId);

            var viewModel = new TipoProdutoViewModel()
            {
                Id = tipoProduto.Id,
                Nome = tipoProduto.Nome
            };

            return PartialView("_editar", viewModel);
        }

        [HttpGet]
        public ActionResult Buscar( string nomeBusca)
        {
          var lista = _unit.TipoProdutoRepository.BuscarPor(p => p.Nome.Contains(nomeBusca)).ToList();

            return PartialView("_tabela", lista);
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
        public ActionResult Editar(TipoProdutoViewModel tipoProduto)
        {
            var tp = new TipoProduto()
            {
                Id = tipoProduto.Id,
                Nome = tipoProduto.Nome
            };

            _unit.TipoProdutoRepository.Alterar(tp);
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Deletar(int tipoId)
        {
            _unit.TipoProdutoRepository.Remover(tipoId);
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