using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public interface IComandaRepositorio : IRepositorioBase<Comanda>
    {
        List<Comanda> ObterComandasSimples();
        Comanda ObterComProdutos(int id);
    }
}
