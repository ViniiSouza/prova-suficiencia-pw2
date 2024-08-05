using ProgWebII.Infra;
using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public class ComandaRepositorio : RepositorioBase<Comanda>, IRepositorioBase<Comanda>
    {
        public ComandaRepositorio(ContextoBanco contexto) : base(contexto)
        {
        }
    }
}
