using ProgWebII.Infra;
using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IRepositorioBase<Usuario>
    {
        public UsuarioRepositorio(ContextoBanco contexto) : base(contexto) { }
    }
}
