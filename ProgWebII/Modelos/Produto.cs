namespace ProgWebII.Modelos
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public List<ProdutoComanda> ProdutosComanda { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("Nome do produto é obrigatório");
            if (Preco <= 0)
                throw new ArgumentException("Preço do produto é obrigatório");
        }
    }
}
