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

        private UnitOfWork _unit = new UnitOfWork();

        // GET: TipoProduto
        public TipoProduto Get(int id)
        {
            return _unit.TipoProdutoRepository.BuscarPorId(id);
        }

    }
}
