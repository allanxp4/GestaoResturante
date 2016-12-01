using Potatotech.GestaoRestaurante.Repositories;
using Potatotech.GestaoRestaurante.Dominio.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Web.ViewModels;

namespace Potatotech.GestaoRestaurante.Web.Controllers
{
    public class ProdutoController : Controller
    {
        #region PRIVATE

        private UnitOfWork _unit = new UnitOfWork();

        #endregion

        #region GET

        [HttpGet]
        public ActionResult Cadastrar()
        {
            ProdutoViewModel p = new ProdutoViewModel()
            {
                ListaTipoProduto = ListarTipoProduto()
            };

            return View(p);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.ProdutoRepository.Listar();

            ProdutoViewModel p = new ProdutoViewModel()
            {
                ListaTipoProduto = ListarTipoProduto(),
                Produtos = lista
            };

            return View(p);
        }

        [HttpGet]
        public ActionResult ListaProduto()
        {
            var lista = _unit.ProdutoRepository.Listar().Select(p => new {
                id = p.Id,
                nome = p.Nome,
                valor = p.Valor,
                imposto = p.Imposto,
                TipoProduto = p.TipoProduto.Nome
            });

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region POST

        [HttpPost]
        public ActionResult Cadastrar(ProdutoViewModel p)
        {
            Produto produto = new Produto()
            {
                Id = p.Id,
                TipoId = p.TipoId,
                Nome = p.Nome,
                Valor = p.Valor,
                Imposto = p.Imposto
            };

            _unit.ProdutoRepository.Cadastrar(produto);
            _unit.Salvar();

            return RedirectToAction("Listar");
        }

        #endregion

      

        private SelectList ListarTipoProduto()
        {
            var lista = _unit.TipoProdutoRepository.Listar();

            return new SelectList(lista, "Id", "Nome");
        }
    }
}