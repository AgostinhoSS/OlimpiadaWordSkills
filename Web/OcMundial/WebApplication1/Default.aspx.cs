using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaPropriedades = new List<Propriedade>
            { 
            new Propriedade { Titulo = "Propriedade 1", Area = "Área 1", Pessoas = 4, Preco = 1200.00, Imagem = "imagem1.jpg" },
            new Propriedade { Titulo = "Propriedade 2", Area = "Área 2", Pessoas = 6, Preco = 1500.00, Imagem = "imagem2.jpg" },
            new Propriedade { Titulo = "Propriedade 3", Area = "Área 1", Pessoas = 8, Preco = 1800.00, Imagem = "imagem3.jpg" },
            new Propriedade { Titulo = "Propriedade 4", Area = "Área 3", Pessoas = 2, Preco = 900.00, Imagem = "imagem4.jpg" },
            new Propriedade { Titulo = "Propriedade 5", Area = "Área 2", Pessoas = 3, Preco = 1100.00, Imagem = "imagem5.jpg" }
        };

            repeaterItens.DataSource = listaPropriedades;
            repeaterItens.DataBind();
        }
    }
}