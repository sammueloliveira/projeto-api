using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class ServiceNoticia : IServiceNoticia
    {
        private readonly INoticia _Inoticia;
        public ServiceNoticia(INoticia noticia)
        {
            _Inoticia = noticia;
        }
        public async Task AddNoticia(Noticia noticia)
        {
            noticia.DataCadastro =  DateTime.Now;
            noticia.DataAlteracao =  DateTime.Now;
            noticia.Ativo = true;
            await _Inoticia.Add(noticia);
        }
        public async Task UpdateNoticia(Noticia noticia)
        {
            noticia.DataCadastro = DateTime.Now;
            noticia.DataAlteracao = DateTime.Now;
            noticia.Ativo = true;
            await _Inoticia.Update(noticia);
        }
        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _Inoticia.ListarNoticias(n => n.Ativo);
        }

    }
}
