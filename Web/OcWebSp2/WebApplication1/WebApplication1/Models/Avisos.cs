using Microsoft.AspNetCore.Authentication;

namespace ApiWebSp.Models
{
    public class Avisos
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string? Titulo { get; set; }
        public string? Aviso { get; set; }
        public int? IdCurso { get; set; }
        public int? IdTurma { get; set; }
        public string? Imagem { get; set; }
    }
}
