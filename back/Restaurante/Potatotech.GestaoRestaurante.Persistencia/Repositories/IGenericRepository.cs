using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Potatotech.GestaoRestaurante.Persistencia.Repositories
{
    public interface IGenericRepository<T>
    {
        Object Cadastrar(T Rentidade);
        void Alterar(T REntidade);
        void Remover(int id);
        ICollection<T> Listar();
        ICollection<T> Listar(Expression<Func<T, bool>> filtro);
        T BuscarPorId(int id);
        ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro);
        ICollection<T> Paginar(int tamanho, int pagina);
        IEnumerable<T> Paginate<T, T2>(int size, int page, IQueryable<T> source, Expression<Func<T, T2>> getId);

    }
}
