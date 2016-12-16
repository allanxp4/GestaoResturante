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
    public class RecepcaoController : Controller
    {

        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.MesaRepository.Listar();
            

            var viewModel = new RecepcaoViewModel()
            {
                Mesas = lista,
                
            };

            return View(viewModel);
        }

        public ActionResult AlterarStatus(int id)
        {
            var viewModel = new RecepcaoViewModel();
            var mesa = _unit.MesaRepository.BuscarPorId(id);

            if (mesa.Ocupada == false)
            {
                viewModel = new RecepcaoViewModel()
                {
                    
                    Ocupada = true
                };
                mesa.Ocupada = true;
            }
            else
            {
                viewModel = new RecepcaoViewModel()
                {
                    Ocupada = false
                };

                mesa.Ocupada = false;
            }

            _unit.MesaRepository.Alterar(mesa);
            _unit.Salvar();

            return RedirectToAction("Listar", viewModel);
        }
    }
}