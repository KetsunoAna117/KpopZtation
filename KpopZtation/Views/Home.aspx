<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtation.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Home</h2>
    <asp:Panel ID="Home_Body" runat="server">
        <asp:Button CssClass="btn btn-outline-primary" ID="ToHomeBtn" runat="server" Text="Insert Artist" CausesValidation="false"/>        
    </asp:Panel>
</asp:Content>
