using Microsoft.EntityFrameworkCore;
using ProjetoNoticias.Domain.Interfaces.Genericos;
using ProjetoNoticias.Infra.Configuracoes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoNoticias.Infra.Repositorio.Genericos
{
    public class RepositorioGenerico<T> : IGenericos<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;
        public RepositorioGenerico()
        {
            _optionsBuilder = new DbContextOptions<Contexto>();
        }
        public async Task Adicionar(T Objeto)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T Objeto)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> BuscarPorId(int Id)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task Excluir(T Objeto)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> Listar()
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
