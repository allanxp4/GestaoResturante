using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Web.Models;

namespace Potatotech.GestaoRestaurante.Web.NewFolder1
{
    public class UnitOfWork : IDisposable
    {
        private RestauranteContext _context = new RestauranteContext();

        /*
               private IGenericRepository<?> _ambienteRepository;

              public IGenericRepository<?> AmbienteRepository
               {
                   get
                   {
                       if (_ambienteRepository == null)
                       {
                           _ambienteRepository = new GenericRepository<?>(_context);
                       }
                       return _ambienteRepository;
                   }
               } */



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