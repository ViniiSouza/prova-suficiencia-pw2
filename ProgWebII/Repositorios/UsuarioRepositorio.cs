using ProgWebII.Infra;
using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ContextoBanco contexto) : base(contexto) { }

        public bool UsuarioValido(string nome, string senha)
        {
            return _contexto.Set<Usuario>().Any(u => u.Nome == nome && u.Senha == senha);
        }

        public Usuario? ObterPorNome(string nome)
        {
            var entidade = _contexto.Set<Usuario>().FirstOrDefault(u => u.Nome == nome);
            if (entidade == null) return null;
            entidade.Senha = null;
            return entidade;
        }
    }
}
