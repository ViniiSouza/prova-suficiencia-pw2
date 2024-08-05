using System.Text.Json.Serialization;

namespace ProgWebII.DTOs
{
    public class CriarComandaRespostaDTO : CriarComandaRequestDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

    }
}
