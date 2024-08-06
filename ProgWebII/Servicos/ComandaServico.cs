using ProgWebII.DTOs;
using ProgWebII.Modelos;
using ProgWebII.Repositorios;

namespace ProgWebII.Servicos
{
    public class ComandaServico : ServicoBase<Comanda>, IComandaServico
    {

        public ComandaServico(IComandaRepositorio comandaRepositorio) : base(comandaRepositorio)
        {
        }

        public Comanda ObterComProdutos(int id)
        {
            return ((IComandaRepositorio)_repositorio).ObterComProdutos(id);
        }

        public List<Comanda> ObterComandasSimples()
        {
            return ((IComandaRepositorio)_repositorio).ObterComandasSimples();
        }

        public void AlterarProdutos(int comandaId, AlterarComandaRequestDTO dto)
        {
            var comanda = ObterComProdutos(comandaId);
            var produtos = comanda.ProdutosComanda.Select(sel => sel.Produto).ToList();
            foreach (var item in dto.Produtos)
            {
                var produto = produtos.FirstOrDefault(f => f.Id == item.Id);
                if (produto == null)
                    continue;
                produto.Nome = item.Nome;
                produto.Preco = item.Preco ?? produto.Preco;
            }
            _repositorio.Salvar();
        }
    }
}
