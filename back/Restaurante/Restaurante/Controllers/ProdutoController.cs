using Potatotech.GestaoRestaurante.Web;
using Potatotech.GestaoRestaurante.Web.Models;
using Potatotech.GestaoRestaurante.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
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
                Produtos = lista
            };

            return View(p);
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

            return RedirectToAction("Cadastrar");
        }

        #endregion


        private SelectList ListarTipoProduto()
        {
            var lista = _unit.TipoProdutoRepository.Listar();

            return new SelectList(lista, "Id", "Nome");
        }
    }
}