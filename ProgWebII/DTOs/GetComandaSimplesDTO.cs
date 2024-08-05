using System.Text.Json.Serialization;

namespace ProgWebII.DTOs
{
    public class GetComandaSimplesDTO
    {
        [JsonPropertyName("idUsuario")]
        public int UsuarioId { get; set; }

        [JsonPropertyName("nomeUsuario")]
        public string UsuarioNome { get; set; }

        [JsonPropertyName("telefoneUsuario")]
        public string UsuarioTelefone { get; set; }
    }
}
