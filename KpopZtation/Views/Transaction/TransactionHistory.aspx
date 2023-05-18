<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="KpopZtation.Views.Transaction.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mb-3">Transaction History</h3>
    <div>
        <asp:GridView ID="TransactionHistoryGridView" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" />
                <asp:BoundField DataField="Courier" HeaderText="Courier" SortExpression="Courier" />
                <asp:ImageField DataImageUrlField="AlbumImage" DataImageUrlFormatString="~/Assets/AlbumImage/{0}" HeaderText="Album Image" ControlStyle-Height="200px" ControlStyle-CssClass="object-fit-contain border rounded">
                    <ControlStyle CssClass="object-fit-contain border rounded" Height="200px" />
                </asp:ImageField>
                <asp:BoundField DataField="AlbumName" HeaderText="Album Name" SortExpression="AlbumName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="AlbumPrice" HeaderText="Album Price" SortExpression="AlbumPrice" />
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
