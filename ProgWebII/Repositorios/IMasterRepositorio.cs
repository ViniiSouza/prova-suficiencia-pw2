using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public interface IMasterRepositorio : IRepositorioBase<Master>
    {
        bool MasterValido(string login, string senha);
        Master? ObterPorLogin(string login);
    }
}
