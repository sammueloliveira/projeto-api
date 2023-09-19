using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Application.OpenApp
{
    public class NoticiaApp : INoticiaApp
    {
        private readonly INoticia _INoticia;
        private readonly IServiceNoticia _IServiceNoticia;
        public NoticiaApp(INoticia noticia, IServiceNoticia serviceNoticia)
        {
            _INoticia = noticia;
            _IServiceNoticia = serviceNoticia;
        }
        public async Task AddNoticia(Noticia noticia)
        {
            await _IServiceNoticia.AddNoticia(noticia);
        }
        public async Task UpdateNoticia(Noticia noticia)
        {
            await _IServiceNoticia.UpdateNoticia(noticia);
        }
        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _IServiceNoticia.ListarNoticiasAtivas();
        }
        public async Task Add(Noticia objeto)
        {
            await _INoticia.Add(objeto);
        }
        public async Task Delete(Noticia objeto)
        {
            await _INoticia.Delete(objeto);
        }

        public async Task<Noticia> GetEntityById(int id)
        {
            return await _INoticia.GetEntityById(id);
        }

        public async Task<List<Noticia>> List()
        {
            return await _INoticia.List();
        }
        public async Task Update(Noticia objeto)
        {
            await _INoticia.Update(objeto);
        }

      
    }
}
