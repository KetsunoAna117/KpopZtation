<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="KpopZtation.Views.Album.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .SubmitBtn{
            margin-top: 1rem;
        }

        .InsertAlbum_InputField > *:not(:last-child){
            margin-top: 1rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Insert Album</h3>
    <asp:Panel ID="InsertAlbum_InputField" runat="server" CssClass="InsertAlbum_InputField">
        <asp:Panel ID="InsertAlbum_NameInput" runat="server" CssClass="input_field">
            <asp:Label ID="Label1" runat="server" Text="Album Name"></asp:Label>
            <asp:TextBox ID="AlbumNameTxt" runat="server"></asp:TextBox>
            <asp:Label ID="AlbumNameError" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="InsertAlbum_DescriptionInput" runat="server" CssClass="input_field">
            <asp:Label ID="Label3" runat="server" Text="Album Description"></asp:Label>
            <asp:TextBox ID="AlbumDescTxt" runat="server"></asp:TextBox>
            <asp:Label ID="AlbumDescError" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="InsertAlbum_PriceInput" runat="server" CssClass="input_field">
            <asp:Label ID="Label5" runat="server" Text="Album Price"></asp:Label>
            <asp:TextBox ID="AlbumPriceTxt" runat="server"></asp:TextBox>
            <asp:Label ID="AlbumPriceError" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="InsertAlbum_StockInput" runat="server" CssClass="input_field">
            <asp:Label ID="Label7" runat="server" Text="Album Stock"></asp:Label>
            <asp:TextBox ID="AlbumStockTxt" runat="server"></asp:TextBox>
            <asp:Label ID="AlbumStockError" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="InsertAlbum_ImageInput" runat="server" CssClass="input_field">
            <asp:Label ID="Label2" runat="server" Text="Album Image"></asp:Label>
            <asp:FileUpload ID="AlbumImageUpload" runat="server" />
            <asp:Label ID="AlbumImageError" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>

        <asp:Button CssClass="btn btn btn-outline-success SubmitBtn" ID="SubmitBtn" runat="server" Text="Insert Album" OnClick="SubmitBtn_Click"/>
    </asp:Panel>
</asp:Content>
