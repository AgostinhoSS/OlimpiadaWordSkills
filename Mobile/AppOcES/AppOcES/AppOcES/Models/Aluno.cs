using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppOcES.Models
{
    class Aluno
    {
        public int idAluno { get; set; }
        public string nome { get; set; }
        public string CPF { get; set; }
        public Image foto { get; set; }
        public string token { get; set; }
        public string estadoConta { get; set; }
        public string turno { get; set; }
        public string senha { get; set; }
        public string dicaSenha { get; set; }
        public double moedasPerdidas { get; set; }
    }
}
