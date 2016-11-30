using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurante.Controllers
{
    public class RestauranteController : Controller
    {


        #region Private

        UnitOfWork _unit = new UnitOfWork();

        #endregion

        #region Get

        [HttpGet]
        public ActionResult Cadastrar()
        {
            /*RestauranteViewModel viewRestaurante = new RestauranteViewModel()
            {
                qtdAmbientes 
            }; */
            return View();
        }

        #endregion

        #region Post


        #endregion
    }
}