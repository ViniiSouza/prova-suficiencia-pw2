using ProgWebII.Infra;

namespace ProgWebII.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly ContextoBanco _contexto;

        public RepositorioBase(ContextoBanco contexto)
        {
            _contexto = contexto;
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }

        public void Atualizar(T entidade)
        {
            _contexto.Set<T>().Update(entidade);
        }

        public void Inserir(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
        }

        public void Deletar(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        public T ObterPorId(int id)
        {
            return _contexto.Set<T>().Find(id);
        }
    }
}
