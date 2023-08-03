<%@ Page Title="SearchPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="WebApplication1.Pages.SearchPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Repeater ID="repeaterProperty" runat="server">
            <ItemTemplate>
                <div class="col-3">
                    <img class="img-fluid" src="../Images/67818817.jpg" />
                    <p>Título da propriedade</p>
                    <p>Área <%# Eval("Name") %></p>
                    <p>7 pessoas</p>
                    <p>Preço total 90$</p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString='<%$ ConnectionStrings:ComXConnectionString %>'
            SelectCommand="SELECT Items.ID, Items.Title, Items.Capacity, Areas.Name, ItemPrices.Price, ItemPictures.PictureFileName FROM Items INNER JOIN ItemPictures ON Items.ID = ItemPictures.ItemID INNER JOIN ItemPrices ON Items.ID = ItemPrices.ItemID INNER JOIN Areas ON Items.AreaID = Areas.ID WHERE (Areas.ID = 15)"></asp:SqlDataSource>
    </div>

</asp:Content>
