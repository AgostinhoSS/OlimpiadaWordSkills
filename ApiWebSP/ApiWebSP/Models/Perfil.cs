using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebSP.Models
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Mensagem { get; set; }
        public bool Erro { get; set; }
    }
}