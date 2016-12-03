using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Services.DTOs;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class ProdutoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public ICollection<ProdutoDto> Get(string termo)
        {
            var produtos = _unit.ProdutoRepository.BuscarPor(p => p.Nome.Contains(termo));
            return Mapper.Map<ICollection<ProdutoDto>>(produtos);
        }
    }
}
