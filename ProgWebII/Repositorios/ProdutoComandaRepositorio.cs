using ProgWebII.Infra;
using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public class ProdutoComandaRepositorio : RepositorioBase<ProdutoComanda>, IRepositorioBase<ProdutoComanda>
    {
        public ProdutoComandaRepositorio(ContextoBanco contexto) : base(contexto) { }
    }
}
