using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("api/noticia")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaApp _INoticiaApp;

        public NoticiaController(INoticiaApp noticiaApp)
        {
            _INoticiaApp = noticiaApp;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("listar-noticias")]
        public async Task<List<Noticia>> ListarNoticias()
        {
            return await _INoticiaApp.ListarNoticiasAtivas();
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("adicionar-noticia")]
        public async Task<IActionResult> AdicionarNoticia(NoticiaViewModel noticia)
        {
            var noticiaNova = new Noticia
            {
                Titulo = noticia.Titulo,
                Informacao = noticia.Informacao,
                UserId = noticia.IdUsuario 
            };
            await _INoticiaApp.AddNoticia(noticiaNova);

            return Ok(noticiaNova); 
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPut("atualizar-noticia")]
        public async Task<IActionResult> AtualizarNoticia(NoticiaViewModel noticia)
        {
            var noticiaExistente = await _INoticiaApp.GetEntityById(noticia.IdNoticia);
            if (noticiaExistente == null)
            {
                return NotFound(); 
            }

            noticiaExistente.Titulo = noticia.Titulo;
            noticiaExistente.Informacao = noticia.Informacao;
            noticiaExistente.UserId = noticia.IdUsuario; 

            await _INoticiaApp.UpdateNoticia(noticiaExistente);

            return Ok(noticiaExistente); 
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("excluir-noticia")]
        public async Task<IActionResult> ExcluirNoticia(int idNoticia)
        {
            var noticiaExistente = await _INoticiaApp.GetEntityById(idNoticia);
            if (noticiaExistente == null)
            {
                return NotFound(); 
            }

            await _INoticiaApp.Delete(noticiaExistente);

            return NoContent(); 
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarPorId(int idNoticia)
        {
            var noticiaExistente = await _INoticiaApp.GetEntityById(idNoticia);
            if (noticiaExistente == null)
            {
                return NotFound(); 
            }

            return Ok(noticiaExistente); 
        }
    }

}

