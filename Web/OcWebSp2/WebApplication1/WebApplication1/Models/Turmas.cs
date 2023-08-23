namespace ApiWebSp.Models
{
    public class Turmas
    {
        public int Id { get; set; }
        public int? IdCurso { get; set; }
        public string? CodTurma { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public int? QtdMinima { get; set; }
        public int? QtdMaxima { get; set; }
        public int? IdDocente { get; set; }
    }
}
