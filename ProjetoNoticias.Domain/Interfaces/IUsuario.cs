using System.Threading.Tasks;

namespace ProjetoNoticias.Domain.Interfaces
{
    public interface IUsuario
    {
        Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular);
        Task<bool> ExisteUsuario(string email, string senha);
        Task<string> RetornarIdUsuario(string email);
    }
}
