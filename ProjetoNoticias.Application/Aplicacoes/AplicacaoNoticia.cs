using ProjetoNoticias.Application.Interfaces;
using ProjetoNoticias.Domain.Interfaces;
using ProjetoNoticias.Domain.Interfaces.InterfaceServicos;
using ProjetoNoticias.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoNoticias.Application.Aplicacoes
{
    public class AplicacaoNoticia : IAplicacaoNoticia
    {
        INoticia _noticia;
        IServiceNoticia _serviceNoticia;
        public AplicacaoNoticia(INoticia noticia, IServiceNoticia serviceNoticia)
        {
            _noticia = noticia;
            _serviceNoticia = serviceNoticia;
        }

        public async Task AdicionarNoticia(Noticia noticia)
        {
            await _serviceNoticia.AdicionarNoticia(noticia);
        }
        public async Task AtualizarNoticia(Noticia noticia)
        {
            await _serviceNoticia.AtualizarNoticia(noticia);
        }
        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _serviceNoticia.ListarNoticiasAtivas();
        }




        public async Task Adicionar(Noticia Objeto)
        {
            await _noticia.Adicionar(Objeto);
        }
        public async Task Atualizar(Noticia Objeto)
        {
            await _noticia.Atualizar(Objeto);
        }

        public async Task<Noticia> BuscarPorId(int Id)
        {
            return await _noticia.BuscarPorId(Id);
        }

        public async Task Excluir(Noticia Objeto)
        {
            await _noticia.Excluir(Objeto);
        }

        public async Task<List<Noticia>> Listar()
        {
            return await _noticia.Listar();
        }
    }
}
