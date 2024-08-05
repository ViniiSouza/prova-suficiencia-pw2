using System.Text.Json.Serialization;

namespace ProgWebII.DTOs
{
    public class AlterarComandaRequestDTO
    {
        [JsonPropertyName("produtos")]
        public List<ProdutoDTO> Produtos { get; set; }
    }
}
