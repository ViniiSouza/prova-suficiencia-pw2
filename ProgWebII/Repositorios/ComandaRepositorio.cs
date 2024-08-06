using ProgWebII.Infra;
using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public class ComandaRepositorio : RepositorioBase<Comanda>, IComandaRepositorio
    {
        public ComandaRepositorio(ContextoBanco contexto) : base(contexto)
        {
        }
    }
}
