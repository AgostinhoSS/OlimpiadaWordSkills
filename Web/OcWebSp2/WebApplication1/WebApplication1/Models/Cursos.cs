using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Models
{
    public class Cursos
    {
        public int Id { get; set; }
        public string? Nome{ get; set; }
        public int? CargaHoraria { get; set; }
        public Byte[]? Imagem { get; set; }
        public string? Descricao { get; set; }
        public int? IdArea { get; set; }

    }
}
