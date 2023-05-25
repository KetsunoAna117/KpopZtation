<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="KpopZtation.Views.Album.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Album Detail</h3>
    <div class="card mb-3 bg-dark" style="max-width: 1200px;">
        <div class="row g-0 d-flex">
            <div class="col-md-4  align-self-center">
                <asp:Image ID="AlbumImage" CssClass="img-fluid rounded-start " runat="server" />
            </div>
            <div class="col-md-8">
                <div class="card-body d-flex flex-column text-light">
                    <asp:Label ID="AlbumName" runat="server" CssClass="card-title fw-bold"></asp:Label>
                    <asp:Label ID="AlbumDescription" runat="server" CssClass="card-text"></asp:Label>
                </div>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item d-flex justify-content-between text-light bg-dark">
                        <asp:Label ID="AlbumPriceLbl" runat="server" Text="Album Price" CssClass="fw-bold"></asp:Label>
                        <asp:Label ID="AlbumPrice" runat="server"></asp:Label>                        
                    </li>
                    <li class="list-group-item d-flex justify-content-between text-light bg-dark">
                        <asp:Label ID="AlbumStockLbl" runat="server" Text="Album Stock" CssClass="fw-bold "></asp:Label>
                        <asp:Label ID="AlbumStock" runat="server"></asp:Label>                        
                    </li>
                    <asp:Panel ID="AddToCart_div" CssClass="list-group-item text-light bg-dark" runat="server">

                        <asp:Label ID="Label1" runat="server" Text="Buy Quantity" CssClass="fw-bold"></asp:Label>
                        <asp:TextBox ID="AddToCartTxt" runat="server"></asp:TextBox>
                        <asp:Button ID="AddToCartBtn" runat="server" Text="Add To Cart" CssClass="btn btn-success mt-2" OnClick="AddToCartBtn_Click"/>
                        <asp:Label ID="BuyQuantityError" runat="server" ForeColor="Red"></asp:Label>
                    </asp:Panel>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
