
namespace CleanArch.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        void Incluir(T entity);

        void Alterar(T entity);

        T SelecionarPorId(int id);

        List<T> SelecionarTudo();

        void Excluir(int id);
    }
}
