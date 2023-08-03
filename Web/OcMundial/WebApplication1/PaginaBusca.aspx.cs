using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PaginaBusca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        //{

        //    if (IsPostBack) return;
        //    var termo = txtPesquisa.Text.Trim();

        //    SqlDataSource1.SelectParameters.Clear();
        //    SqlDataSource1.SelectParameters.Add("@termoBuscado", $"%{termo}%");

        //    SqlDataSource1.DataBind();
        //}


    }
}