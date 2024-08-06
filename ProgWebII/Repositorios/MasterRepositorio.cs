using ProgWebII.Infra;
using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public class MasterRepositorio : RepositorioBase<Master>, IMasterRepositorio
    {
        public MasterRepositorio(ContextoBanco contexto) : base(contexto)
        {
        }

        public bool MasterValido(string login, string senha)
        {
            return _contexto.Set<Master>().Any(u => u.Login == login && u.Senha == senha);
        }

        public Master? ObterPorLogin(string login)
        {
            var entidade = _contexto.Set<Master>().FirstOrDefault(u => u.Login == login);
            if (entidade == null) return null;
            entidade.Senha = null;
            return entidade;
        }
    }
}
