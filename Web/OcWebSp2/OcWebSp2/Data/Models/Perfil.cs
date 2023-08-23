using System.Text.Json.Serialization;

namespace BlazorApp1.Data.Models
{
    public class Perfil
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }
    }
}
