namespace OcWebSp.Data.Models
{
    public class CadastroAvisoForm
    {
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string TextoAviso { get; set; }
        public TipoAviso? Tipo { get; set; }
        public string Image { get; set; }
    }
}
