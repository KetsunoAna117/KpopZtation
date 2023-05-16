<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtation.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Home_ArtistData{
            margin-top: 2rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Home</h3>
    <asp:Panel ID="Home_Body" runat="server">
        <asp:Button CssClass="btn btn-success" ID="InsertArtistBtn" runat="server" Text="Insert Artist" CausesValidation="false" OnClick="InsertArtistBtn_Click"/> 
        
        <asp:Panel ID="Home_ArtistData" runat="server" CssClass="Home_ArtistData">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-striped" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="ArtistID">
                <Columns>
                    <asp:ButtonField CommandName="Select" HeaderText="Select" ShowHeader="True" Text="Details" />
                    <asp:BoundField DataField="ArtistName" HeaderText="Artist Name" SortExpression="ArtistName" />
                    <asp:ImageField DataImageUrlField="ArtistImage" DataImageUrlFormatString="~/Assets/ArtistImage/{0}" HeaderText="Artist Image" ControlStyle-Height="200px" ControlStyle-CssClass="object-fit-contain border rounded">
                        <ControlStyle CssClass="object-fit-contain border rounded" Height="200px" />
                    </asp:ImageField>
                    <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Update" ShowHeader="True" Text="Update" ControlStyle-CssClass="btn btn-outline-warning">
                    <ControlStyle CssClass="btn btn-outline-warning" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" ControlStyle-CssClass="btn btn-outline-danger">            
                    <ControlStyle CssClass="btn btn-outline-danger" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
