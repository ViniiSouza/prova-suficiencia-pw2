using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario? ObterPorNome(string nome);
        bool UsuarioValido(string nome, string senha);
    }
}
