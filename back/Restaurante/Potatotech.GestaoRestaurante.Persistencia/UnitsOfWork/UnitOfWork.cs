using System;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.Repositories;

namespace Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork
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