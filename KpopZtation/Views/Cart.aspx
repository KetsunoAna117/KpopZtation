<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="KpopZtation.Views.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Cart</h3>
    <div class="cart_page ">
        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" CssClass="btn btn-success" OnClick="CheckoutBtn_Click"/> 
        <asp:GridView ID="CartGridView" runat="server" CssClass="mt-4 table table-dark table-striped" AutoGenerateColumns="False" OnRowDeleting="CartGridView_RowDeleting" DataKeyNames="AlbumID">
            <Columns>
                <asp:ImageField DataImageUrlField="AlbumImage" DataImageUrlFormatString="~/Assets/AlbumImage/{0}" HeaderText="Album Picture" ControlStyle-Height="200px" ControlStyle-CssClass="object-fit-contain border rounded">
                    <ControlStyle CssClass="object-fit-contain border rounded" Height="200px" />
                </asp:ImageField>
                <asp:BoundField DataField="AlbumName" HeaderText="Album Name" SortExpression="AlbumName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Qty" />
                <asp:BoundField DataField="AlbumPrice" HeaderText="Album Price" SortExpression="AlbumPrice/pcs" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" ControlStyle-CssClass="btn btn-danger" HeaderText="Delete" ShowHeader="True" Text="Delete" />
            </Columns>

        </asp:GridView>

    </div>
</asp:Content>
