using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Potatotech.GestaoRestaurante.Dominio.Models;

namespace Potatotech.GestaoRestaurante.Persistencia.Repositories
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

        public virtual object Cadastrar(T entidade) 
        {
            _dbSet.Add(entidade);
            return entidade;

        }
        
        public virtual ICollection<T> Listar()
        {
            return _dbSet.ToList();
        }

        public virtual ICollection<T> Listar(Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro).Take(5).ToList();
        }

        public virtual void Remover(int id)
        {
            var entity = BuscarPorId(id);
            _dbSet.Remove(entity);
        }

        public virtual ICollection<T> Paginar(int tamanho, int pagina)
        {
            return _dbSet.Skip(tamanho*pagina).Take(tamanho).ToList();
        }

        public IEnumerable<T> Paginate<T, T2>(int size, int page, IQueryable<T> source, Expression<Func<T, T2>> getId)
        {
            //return _dbSet.OrderBy(getId).Skip(size * page).Take(size).ToList();
            return null;
        }

        
    }
}