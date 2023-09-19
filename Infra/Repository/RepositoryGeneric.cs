using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Infra.Repository
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Contexto> _dbContextOptions;
        public RepositoryGeneric()
        {
            _dbContextOptions = new DbContextOptions<Contexto>();
        }
       public async Task Add(T objeto)
        {
           using (var data = new Contexto(_dbContextOptions))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Update(T objeto)
        {
            using (var data = new Contexto(_dbContextOptions))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objeto)
        {
            using (var data = new Contexto(_dbContextOptions))
            {
                data.Set<T>().Remove(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new Contexto(_dbContextOptions))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new Contexto(_dbContextOptions))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RepositoryGeneric()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
