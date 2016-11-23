using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Repositories
{
    public interface IGenericRepository<T>
    {
        void Cadastrar(T Rentidade);
        void Alterar(T REntidade);
        void Remover(int id);
        ICollection<T> Listar();
        T BuscarPorId(int id);
        ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro);
    }
}
