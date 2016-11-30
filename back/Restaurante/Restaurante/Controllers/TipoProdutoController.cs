using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;

namespace Potatotech.GestaoRestaurante.Controllers
{
    public class TipoProdutoController : Controller
    {

        #region PRIVATE

        private 
            
            UnitOfWork _unit = new UnitOfWork();

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

            return RedirectToAction("Cadastrar");
        }

        #endregion
    }
}