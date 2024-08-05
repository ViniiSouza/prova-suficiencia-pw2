namespace ProgWebII.Modelos
{
    public class Comanda
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public List<ProdutoComanda> ProdutosComanda { get; set; }
    }
}
