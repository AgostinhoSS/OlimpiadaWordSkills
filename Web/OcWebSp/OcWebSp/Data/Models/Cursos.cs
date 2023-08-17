using System.Drawing;

namespace OcWebSp.Data.Models
{
    public class Cursos
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? CargaHoraria { get; set; }
        public Byte[]? Imagem { get; set; }
        public string? Descricao { get; set; }
        public int? IdArea { get; set; }
    }
}

