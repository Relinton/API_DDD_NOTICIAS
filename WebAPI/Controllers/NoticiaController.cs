using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNoticias.Application.Interfaces;
using ProjetoNoticias.Entidades.Entidades;
using ProjetoNoticias.Entidades.Notificacoes;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly IAplicacaoNoticia _aplicacaoNoticia;
        public NoticiaController(IAplicacaoNoticia aplicacaoNoticia)
        {
            _aplicacaoNoticia = aplicacaoNoticia;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("api/ListarNoticias")]
        public async Task<List<Noticia>> ListarNoticias()
        {
            return await _aplicacaoNoticia.ListarNoticiasAtivas();
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("api/AdicionarNoticia")]
        public async Task<List<Notifica>> AdicionarNoticia(NoticiaModel noticia)
        {
            var noticiaNova = new Noticia();
            noticiaNova.Titulo = noticia.Titulo;
            noticiaNova.Informacao = noticia.Informacao;
            noticiaNova.UserId = await RetornarIdUsuarioLogado();
            await _aplicacaoNoticia.AdicionarNoticia(noticiaNova);

            return noticiaNova.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("api/AtualizarNoticia")]
        public async Task<List<Notifica>> AtualizarNoticia(NoticiaModel noticia)
        {
            var noticiaNova = await _aplicacaoNoticia.BuscarPorId(noticia.IdNoticia);
            noticiaNova.Titulo = noticia.Titulo;
            noticiaNova.Informacao = noticia.Informacao;
            noticiaNova.UserId = await RetornarIdUsuarioLogado();
            await _aplicacaoNoticia.AtualizarNoticia(noticiaNova);

            return noticiaNova.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("api/ExcluirNoticia")]
        public async Task<List<Notifica>> ExcluirNoticia(NoticiaModel noticia)
        {
            var noticiaNova = await _aplicacaoNoticia.BuscarPorId(noticia.IdNoticia);
            await _aplicacaoNoticia.Excluir(noticiaNova);

            return noticiaNova.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("api/BuscarPorId")]
        public async Task<Noticia> BuscarPorId(NoticiaModel noticia)
        {
            var noticiaNova = await _aplicacaoNoticia.BuscarPorId(noticia.IdNoticia);

            return noticiaNova;
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
