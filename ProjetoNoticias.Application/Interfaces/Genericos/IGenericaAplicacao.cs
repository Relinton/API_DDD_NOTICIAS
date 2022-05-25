using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoNoticias.Application.Interfaces.Genericos
{
    public interface IGenericaAplicacao <T> where T : class
    {
        Task Adicionar(T Objeto);
        Task Atualizar(T Objeto);
        Task Excluir(T Objeto);
        Task<T> BuscarPorId(int Id);
        Task<List<T>> Listar();
    }
}
