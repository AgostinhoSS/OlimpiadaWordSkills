using System.Drawing;

namespace OcWebSp.Data.Models
{
    public class Pessoas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public char Sexo { get; set; }
        public byte[] Foto { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
