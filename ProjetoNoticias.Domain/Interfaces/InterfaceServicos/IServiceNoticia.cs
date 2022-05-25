using ProjetoNoticias.Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoNoticias.Domain.Interfaces.InterfaceServicos
{
    public interface IServiceNoticia
    {
        Task AdicionarNoticia(Noticia noticia);
        Task AtualizarNoticia(Noticia noticia);
        Task<List<Noticia>> ListarNoticiasAtivas();
    }
}
