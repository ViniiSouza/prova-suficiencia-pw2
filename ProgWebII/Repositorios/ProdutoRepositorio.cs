using ProgWebII.Infra;
using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IRepositorioBase<Produto>
    {
        public ProdutoRepositorio(ContextoBanco contexto) : base(contexto)
        {
        }
    }
}
