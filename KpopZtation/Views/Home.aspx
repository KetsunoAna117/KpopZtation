<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtation.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Home_ArtistData{
            margin-top: 2rem;
        }

        .artist_image{
            justify-self: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Home</h3>
    <asp:Panel ID="Home_Body" runat="server">
        <asp:Button CssClass="btn btn-success" ID="InsertArtistBtn" runat="server" Text="Insert Artist" CausesValidation="false" OnClick="InsertArtistBtn_Click"/> 
        
        <asp:Panel ID="Home_ArtistData" runat="server" CssClass="Home_ArtistData card-group">
            <asp:Repeater ID="CardRepeater" runat="server">
                <ItemTemplate>
                    <div class="card d-flex flex-column justify-content-lg-start" style="width: 18rem;">
                        <img src="../Assets/ArtistImage/<%# Eval("ArtistImage") %>" class="card-img-top artist_image" style="width: 18rem; height: 24rem" alt="...">
                        <div class="card-body flex">
                            <h5 class="card-title"><%# Eval("Artistname") %></h5>
                            <asp:Button ID="ToThisArtistDetail" runat="server" Text="More Details..." CssClass="btn btn-outline-primary"/>
                            <asp:Panel ID="ActionBtn" CssClass="btn-group btn-group-sm" runat="server">
                                <asp:Button ID="ToUpdateArtist" runat="server" CssClass="btn btn-warning" Text="Update"/>
                                <asp:Button ID="ToDeleteArtist" runat="server" CssClass="btn btn-danger" Text="Delete" />
                            </asp:Panel>
                      </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
