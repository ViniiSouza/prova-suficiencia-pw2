
namespace ProgWebII.Servicos
{
    public interface IServicoBase<T> where T : class
    {
        void Atualizar(T entity);
        void Deletar(T entity);
        void Inserir(T entity);
        T ObterPorId(int id);
        IEnumerable<T> ObterTodos();
    }
}