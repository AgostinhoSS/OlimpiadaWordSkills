<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaBusca.aspx.cs" Inherits="WebApplication1.PaginaBusca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>

        <header class="container-fluid bg-info py-2">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col order-0">
                        <img src="Images/wsc2022se_tp09_logo_actual_en.png" height="60" />
                    </div>
                    <div class="col-md-6 order-2">
                        <asp:TextBox  CssClass="mt-3 mt-sm-0 form-control"   
                            
                            AutoPostBack="true"    
                            runat="server" ID="txtPesquisa"/>
                    </div>
                    <div class="col order-1 order-sm-last text-end">
                        Welcome John Doe
                    </div>
                </div>
            </div>
        </header>
        <main class="container bg-white">
            <div class="row">
                <asp:Repeater ID="repeaterProperty" runat="server">
                    <ItemTemplate>
                        <div class="col-3">
                            <img class="img-fluid" src="../Images/67818817.jpg" />
                            <p>Título da propriedade</p>
                            <p>Área <%# Eval("Name") %></p>
                            <p>7 pessoas</p>
                            <p>Preço total 90$</p>
                            <asp:HyperLink ID="hypPagina2" Text="Ir para a página 2" runat="server" NavigateUrl="~/PaginaDetalhada.aspx?ItemId=15" />

                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString='<%$ ConnectionStrings:ComXConnectionString %>'
                    SelectCommand="SELECT Items.ID, Items.Title, Items.Capacity, Areas.Name, ItemPictures.PictureFileName FROM Items INNER JOIN ItemPictures ON Items.ID = ItemPictures.ItemID INNER JOIN Areas ON Items.AreaID = Areas.ID WHERE (Areas.Name LIKE @termoBuscado)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtPesquisa" PropertyName="Text" Name="termoBuscado"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </main>
        <hr />
        <footer>
            <p>&copy; <%: DateTime.Now.Year %> - My ASP.NET Application</p>
        </footer>

    </form>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Scripts/bootstrap.js") %>
    </asp:PlaceHolder>

</body>
</html>
