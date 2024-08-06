using Microsoft.EntityFrameworkCore;
using ProgWebII.Infra;
using ProgWebII.Modelos;

namespace ProgWebII.Repositorios
{
    public class ComandaRepositorio : RepositorioBase<Comanda>, IComandaRepositorio
    {
        public ComandaRepositorio(ContextoBanco contexto) : base(contexto)
        {
        }

        public Comanda ObterComProdutos(int id)
        {
            return _contexto.Set<Comanda>()
                            .Where(where => where.Id == id)
                            .Include(include => include.Usuario)
                            .Include(include => include.ProdutosComanda)
                            .ThenInclude(then => then.Produto).FirstOrDefault();
        }

        public List<Comanda> ObterComandasSimples()
        {
            return _contexto.Set<Comanda>()
                            .Include(include => include.Usuario)
                            .ToList();
        }
    }
}
