using System.Data.SqlClient;

namespace OcMundial.Data.Core
{
    public class Propriedade
    {
        public string Titulo { get; set; }
        public string Area { get; set; }
        public int Pessoas { get; set; }
        public double Preco { get; set; }
        public string Imagem{ get; set; }

    }
}
