using ProgWebII.Modelos;
using ProgWebII.Repositorios;

namespace ProgWebII.Servicos
{
    public class ComandaServico : ServicoBase<Comanda>, IComandaServico
    {
        private readonly IComandaRepositorio _comandaRepositorio;

        public ComandaServico(IRepositorioBase<Comanda> comandaRepositorio) : base(comandaRepositorio)
        {
        }
    }
}
