namespace ProgWebII.Repositorios
{
    public interface IRepositorioBase<in T> where T : class
    {
        void Atualizar(T entidade);
        void Deletar(T entidade);
        void Inserir(T entidade);
        void Salvar();
    }
}
