using System.Text.Json.Serialization;

namespace ProgWebII.DTOs
{
    public class CriarComandaRequestDTO
    {
        [JsonPropertyName("idUsuario")]
        public int UsuarioId { get; set; }

        [JsonPropertyName("nomeUsuario")]
        public string UsuarioNome { get; set; }

        [JsonPropertyName("telefoneUsuario")]
        public string UsuarioTelefone { get; set; }

        [JsonPropertyName("produtos")]
        public List<ProdutoDTO> Produtos { get; set; }
    }

    public class ProdutoDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("preco")]
        public decimal Preco { get; set; }
    }
}
