using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork;
using Potatotech.GestaoRestaurante.Services.DTOs;
using Potatotech.GestaoRestaurante.Dominio.Models;

namespace Potatotech.GestaoRestaurante.Services.Controllers
{
    public class ProdutoController : ApiController
    {
        #region PRIVATE
        private UnitOfWork _unit = new UnitOfWork();
        #endregion

        #region GET
        public ICollection<ProdutoDto> Get(string termo)
        {
            var produtos = _unit.ProdutoRepository.BuscarPor(p => p.Nome.Contains(termo));
            return Mapper.Map<ICollection<ProdutoDto>>(produtos);
        }

        public ICollection<ProdutoDto> Get()
        {
            var produtos = _unit.ProdutoRepository.Listar();
            return Mapper.Map<ICollection<ProdutoDto>>(produtos);
        }
       

        public Produto Get(int id)
        {
            return _unit.ProdutoRepository.BuscarPorId(id);
        }
        #endregion

        #region DELETE
        public void Delete(int id)
        {
            _unit.ProdutoRepository.Remover(id);
            _unit.Salvar();
        }
        #endregion

    }
}
