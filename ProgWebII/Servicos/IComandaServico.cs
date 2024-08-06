using ProgWebII.DTOs;
using ProgWebII.Modelos;

namespace ProgWebII.Servicos
{
    public interface IComandaServico : IServicoBase<Comanda>
    {
        void AlterarProdutos(int comandaId, AlterarComandaRequestDTO dto);
        List<Comanda> ObterComandasSimples();
        Comanda ObterComProdutos(int id);
    }
}
