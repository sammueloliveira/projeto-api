using Domain.Entities;

namespace Application.Interfaces
{
    public interface INoticiaApp : IGenericApp<Noticia>
    {
        Task AddNoticia(Noticia noticia);
        Task UpdateNoticia(Noticia noticia);
        Task<List<Noticia>> ListarNoticiasAtivas();
    }
}
