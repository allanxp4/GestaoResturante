using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Potatotech.GestaoRestaurante.Web.Controllers
{
    public class RestauranteController : Controller
    {

        #region Private

        UnitOfWork _unit = new UnitOfWork();

        #endregion

        #region Get

        [HttpGet]
        public ActionResult Listar()
        {
            RestauranteViewModel viewRestaurante = new RestauranteViewModel()
            {
                listaAmbientes = _unit.AmbienteRepository.Listar()
            };
            return View(viewRestaurante);
        }

        #endregion

        #region Post

        [HttpPost]
        public ActionResult Cadastrar(RestauranteViewModel viewRestaurante)
        {
            Ambiente ambiente = new Ambiente()
            {
                Id = viewRestaurante.ambiente.Id,
                Nome = viewRestaurante.ambiente.Nome
            };
            _unit.AmbienteRepository.Cadastrar(ambiente);
            _unit.Salvar();
            return RedirectToAction("Listar");
        }

        //[HttpPost]
        public ActionResult Deletar(int idAmb)
        {
            _unit.AmbienteRepository.Remover(idAmb);
            _unit.Salvar();
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Editar(RestauranteViewModel viewRestaurante)
        {
            Ambiente ambiente = new Ambiente()
            {
                Id = viewRestaurante.ambiente.Id,
                Nome = viewRestaurante.ambiente.Nome
            };
            _unit.AmbienteRepository.Alterar(ambiente);
            _unit.Salvar();
            return RedirectToAction("Listar");
        }

        #endregion

    }
}