using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected readonly Contexto _contexto;

        public BaseRepository(Contexto contexto)
        {
            _contexto = contexto;  
        }

        public void Incluir(T entity)
        {
            _contexto.Set<T>().Add(entity);
            _contexto.SaveChanges();
        }

        public async Task<T> Incluir2(T entity)
        {
            _contexto.Set<T>().Add(entity);
            _contexto.SaveChanges();
            return _contexto.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
        }

        public void Alterar(T entity)
        {
            _contexto.Set<T>().Update(entity);
            _contexto.SaveChanges();
        }

        public async Task<T> Alterar2(T entity)
        {
            _contexto.Set<T>().Update(entity);
            _contexto.SaveChanges();
            return _contexto.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
        }

        public T SelecionarPorId(int id)
        {
            return _contexto.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> SelecionarPorId2(int id)
        {
            return _contexto.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<T> SelecionarTudo()
        {
            return _contexto.Set<T>().ToList();
        }

        public async Task<List<T>> SelecionarTudo2()
        {
            return await _contexto.Set<T>().ToListAsync();
        }

        public void Excluir(int id)
        {
            var entity = SelecionarPorId(id);
            _contexto.Set<T>().Remove(entity);
            _contexto.SaveChanges();
        }

        //public async Task<Unit> Excluir2(int id)
        //{
        //    var entity = SelecionarPorId(id);
        //    _contexto.Set<T>().Remove(entity);
        //    _contexto.SaveChanges();
        //}

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
