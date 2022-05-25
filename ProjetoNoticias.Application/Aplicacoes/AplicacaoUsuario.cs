using ProjetoNoticias.Application.Interfaces;
using ProjetoNoticias.Domain.Interfaces;
using System.Threading.Tasks;

namespace ProjetoNoticias.Application.Aplicacoes
{
    public class AplicacaoUsuario : IAplicacaoUsuario
    {
        IUsuario _usuario;
        public AplicacaoUsuario(IUsuario usuario)
        {
            _usuario = usuario;
        }
        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            return await _usuario.AdicionarUsuario(email, senha, idade, celular);
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            return await _usuario.ExisteUsuario(email, senha);
        }

        public async Task<string> RetornarIdUsuario(string email)
        {
            return await _usuario.RetornarIdUsuario(email);
        }
    }
}
