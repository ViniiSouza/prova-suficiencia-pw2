using ProgWebII.Repositorios;

namespace ProgWebII.Servicos
{
    public class ServicoBase<T> : IServicoBase<T> where T : class
    {
        protected readonly IRepositorioBase<T> _repositorio;

        public ServicoBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Inserir(T entity)
        {
            _repositorio.Inserir(entity);
            _repositorio.Salvar();
        }

        public void Atualizar(T entity)
        {
            _repositorio.Atualizar(entity);
            _repositorio.Salvar();
        }

        public void Deletar(T entity)
        {
            _repositorio.Deletar(entity);
            _repositorio.Salvar();
        }

        public T ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
    }
}
