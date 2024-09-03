
namespace CleanArch.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        void Incluir(T entity);
        Task<T> Incluir2(T entity);
        void Alterar(T entity);
        Task<T> Alterar2(T entity);
        void Excluir(int id);
        Task Excluir2(int id);
        T SelecionarPorId(int id);
        Task<T> SelecionarPorId2(int id);
        List<T> SelecionarTudo();
        Task<List<T>> SelecionarTudo2();
    }
}
