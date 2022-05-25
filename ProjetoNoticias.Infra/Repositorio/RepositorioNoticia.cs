using Microsoft.EntityFrameworkCore;
using ProjetoNoticias.Domain.Interfaces;
using ProjetoNoticias.Entidades.Entidades;
using ProjetoNoticias.Infra.Configuracoes;
using ProjetoNoticias.Infra.Repositorio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjetoNoticias.Infra.Repositorio
{
    public class RepositorioNoticia : RepositorioGenerico<Noticia>, INoticia
    {
        private readonly DbContextOptions<Contexto> _optionsbuilder;
        public RepositorioNoticia()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }
        public async Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia, bool>> exNoticia)
        {
            using (var banco = new Contexto(_optionsbuilder))
            {
                return await banco.Noticia.Where(exNoticia).AsNoTracking().ToListAsync();
            }
        }
    }
}
