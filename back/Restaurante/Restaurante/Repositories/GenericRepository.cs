using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Potatotech.GestaoRestaurante.Web.Models;

namespace Potatotech.GestaoRestaurante.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected RestauranteContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(RestauranteContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Alterar(T entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro).ToList();
        }

        public virtual T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
        }

        public virtual ICollection<T> Listar()
        {
            return _dbSet.ToList();
        }

        public virtual void Remover(int id)
        {
            var entity = BuscarPorId(id);
            _dbSet.Remove(entity);
        }
    }
}