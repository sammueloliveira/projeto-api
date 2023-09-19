using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.RepositoryNoticia
{
    public class RepositoryNoticia : RepositoryGeneric<Noticia>, INoticia
    {
        private readonly DbContextOptions<Contexto> _dbContextOptions;
        public RepositoryNoticia()
        {
            _dbContextOptions = new DbContextOptions<Contexto>();
        }
        public async Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia, bool>> exNoticia)
        {
            using (var banco = new Contexto(_dbContextOptions))
            {
                return await banco.Noticias.Where(exNoticia).AsNoTracking().ToListAsync();
            }
        }
    }
}
