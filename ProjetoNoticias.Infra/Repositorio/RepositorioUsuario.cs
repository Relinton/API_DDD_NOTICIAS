using Microsoft.EntityFrameworkCore;
using ProjetoNoticias.Domain.Interfaces;
using ProjetoNoticias.Entidades.Entidades;
using ProjetoNoticias.Entidades.Entidades.Enums;
using ProjetoNoticias.Infra.Configuracoes;
using ProjetoNoticias.Infra.Repositorio.Genericos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNoticias.Infra.Repositorio
{
    public class RepositorioUsuario : RepositorioGenerico<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<Contexto> _optionsbuilder;
        public RepositorioUsuario()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }
        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            try
            {
                using (var banco = new Contexto(_optionsbuilder))
                {
                    await banco.ApplicationUser.AddAsync(
                        new ApplicationUser
                        {
                            Email = email,
                            PasswordHash = senha,
                            Idade = idade,
                            Celular = celular,
                            TipoUsuario = TipoUsuario.Comum
                        });
                    await banco.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var banco = new Contexto(_optionsbuilder))
                {
                    return await banco.ApplicationUser
                        .Where(u => u.Email.Equals(email) && u.PasswordHash.Equals(senha))
                        .AsNoTracking()
                        .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> RetornarIdUsuario(string email)
        {
            try
            {
                using (var banco = new Contexto(_optionsbuilder))
                {
                    var usuario = await banco.ApplicationUser
                        .Where(u => u.Email.Equals(email))
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    return usuario.Id;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
