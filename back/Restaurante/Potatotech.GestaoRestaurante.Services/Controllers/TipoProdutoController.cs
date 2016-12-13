using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class TipoProdutoController : ApiController
    {
        #region PRIVATE
        private UnitOfWork _unit = new UnitOfWork();
        #endregion PRIVATE
        // GET: TipoProduto
        #region GET
        public TipoProduto Get(int id)
        {
            return _unit.TipoProdutoRepository.BuscarPorId(id);
        }
        #endregion GET

    }
}
