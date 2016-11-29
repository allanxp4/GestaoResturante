using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Web.Models;
using Potatotech.GestaoRestaurante.Web.Repositories;

namespace Potatotech.GestaoRestaurante.Web
{
    public class UnitOfWork : IDisposable
    {
        private RestauranteContext _context = new RestauranteContext();

        private IGenericRepository<TipoProduto> _tipoProdutoRepository;
        private IGenericRepository<Produto> _produtoRepository;
                
        public IGenericRepository<Produto> ProdutoRepository
        {
            get
            {
                if(_produtoRepository == null)
                {
                    _produtoRepository = new GenericRepository<Produto>(_context);
                }
                return _produtoRepository;
            }
          
        }

        public IGenericRepository<TipoProduto> TipoProdutoRepository
        {
            get
            {
                if (_tipoProdutoRepository == null)
                {
                    _tipoProdutoRepository = new GenericRepository<TipoProduto>(_context);
                }
                return _tipoProdutoRepository;
            }
        }



        public void Salvar()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}