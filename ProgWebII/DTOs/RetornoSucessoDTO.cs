﻿using System.Text.Json.Serialization;

namespace ProgWebII.DTOs
{
    public class RetornoSucessoDTO
    {
        [JsonPropertyName("success")]
        public SucessoDTO Success { get; set; }

        public RetornoSucessoDTO(string mensagem)
        {
            Success = new SucessoDTO { Text = mensagem };
        }
    }

    public class SucessoDTO
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
