using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
     public interface INoticia : IGeneric<Noticia>
    {
        Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia, bool>> exNoticia);
    }
}
