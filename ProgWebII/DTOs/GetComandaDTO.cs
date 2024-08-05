using System.Text.Json.Serialization;

namespace ProgWebII.DTOs
{
    public class GetComandaDTO : GetComandaSimplesDTO
    {
        [JsonPropertyName("produtos")]
        public List<ProdutoDTO> Produtos { get; set; }
    }
}
