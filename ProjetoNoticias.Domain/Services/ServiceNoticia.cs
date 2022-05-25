using ProjetoNoticias.Domain.Interfaces;
using ProjetoNoticias.Domain.Interfaces.InterfaceServicos;
using ProjetoNoticias.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoNoticias.Domain.Services
{
    public class ServiceNoticia : IServiceNoticia
    {
        private readonly INoticia _noticia;
        public ServiceNoticia(INoticia noticia)
        {
            _noticia = noticia;
        }
        public async Task AdicionarNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidarPropriedadeString(noticia.Titulo, "Titulo");
            var validarInformacao = noticia.ValidarPropriedadeString(noticia.Informacao, "Informacao");

            if (validarTitulo && validarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _noticia.Adicionar(noticia);
            }
        }

        public async Task AtualizarNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidarPropriedadeString(noticia.Titulo, "Titulo");
            var validarInformacao = noticia.ValidarPropriedadeString(noticia.Informacao, "Informacao");

            if (validarTitulo && validarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _noticia.Atualizar(noticia);
            }
        }

        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _noticia.ListarNoticias(n => n.Ativo);
        }
    }
}
