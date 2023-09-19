using Domain.Entities;

namespace Domain.InterfaceServices
{
     public interface IServiceNoticia
    {
        Task AddNoticia(Noticia noticia);
        Task UpdateNoticia(Noticia noticia);
        Task<List<Noticia>> ListarNoticiasAtivas();
    }
}
