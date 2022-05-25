using ProjetoNoticias.Application.Interfaces.Genericos;
using ProjetoNoticias.Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoNoticias.Application.Interfaces
{
    public interface IAplicacaoNoticia : IGenericaAplicacao<Noticia>
    {
        Task AdicionarNoticia(Noticia noticia);
        Task AtualizarNoticia(Noticia noticia);
        Task<List<Noticia>> ListarNoticiasAtivas();
    }
}
