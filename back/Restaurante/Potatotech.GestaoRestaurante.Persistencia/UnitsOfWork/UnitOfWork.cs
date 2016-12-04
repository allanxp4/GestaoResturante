using System;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Persistencia.Repositories;

namespace Potatotech.GestaoRestaurante.Persistencia.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private RestauranteContext _context = new RestauranteContext();

        #region Private

        private IGenericRepository<TipoProduto> _tipoProdutoRepository;
        private IGenericRepository<Produto> _produtoRepository;
        private IGenericRepository<Ambiente> _ambienteRepository;
        private IGenericRepository<Pedido> _pedidoRepository;
        private IGenericRepository<Mesa> _mesaRepository;
        private IGenericRepository<Conta> _contaRepository;
        private IGenericRepository<PedidosDoProduto> _pedidosDoProutoRepository;

        #endregion

        #region Properties

        public IGenericRepository<Ambiente> AmbienteRepository
        {
            get
            {
                if (_ambienteRepository == null)
                {
                    _ambienteRepository = new GenericRepository<Ambiente>(_context);
                }
                return _ambienteRepository;
            }
        }

        public IGenericRepository<Conta> ContaRepository
        {
            get
            {
                if (_contaRepository == null)
                {
                    _contaRepository = new GenericRepository<Conta>(_context);
                }
                return _contaRepository;
            }

        }

        public IGenericRepository<Mesa> MesaRepository
        {
            get
            {
                if (_mesaRepository == null)
                {
                    _mesaRepository = new GenericRepository<Mesa>(_context);
                }
                return _mesaRepository;
            }

        }

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

        #endregion

        public IGenericRepository<Pedido> PedidoRepository
        {
            get
            {
                if (_pedidoRepository == null)
                {
                    _pedidoRepository = new GenericRepository<Pedido>(_context);
                }
                return _pedidoRepository;
            }
        }

        public IGenericRepository<PedidosDoProduto> PedidosDopRodutoRepository
        {
            get
            {
                if (_pedidosDoProutoRepository == null)
                {
                    _pedidosDoProutoRepository = new GenericRepository<PedidosDoProduto>(_context);
                }
                return _pedidosDoProutoRepository;
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