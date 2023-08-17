namespace OcWebSp.Data.Models
{
    public class CadastroAvisoForm
    {
        public int? IdTurma { get; set; }
        public int? IdCurso { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Aviso { get; set; }
        public TipoAviso? Tipo { get; set; }
        public string Image { get; set; }
    }
}
