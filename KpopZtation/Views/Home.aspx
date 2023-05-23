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
        <asp:Button CssClass="btn btn-success mb-3" ID="InsertArtistBtn" runat="server" Text="Insert Artist" CausesValidation="false" OnClick="InsertArtistBtn_Click"/> 
        
        <asp:Panel ID="Home_ArtistData" runat="server" CssClass="Home_ArtistDatarow card-group row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="CardRepeater" runat="server" OnItemDataBound="CardRepeater_ItemDataBound">
                <ItemTemplate>
                    <div style="max-width: 18rem;" class="col me-4 mb-4">
                        <asp:LinkButton ID="Card" runat="server" CssClass="card border-primary mb-3 h-100 d-flex flex-column justify-content-center" OnClick="Card_Click" CommandArgument='<%# Eval("ArtistID") %>'>
                            <img src="../Assets/ArtistImage/<%# Eval("ArtistImage") %>" class="card-img-top artist_image" style="width: 18rem; height: 24rem; object-fit: cover" alt="...">
                            <div class="card-body flex">
                                <h5 class="card-title"><%# Eval("Artistname") %></h5>
                                <asp:Panel ID="ActionBtn" CssClass="btn-group btn-group-sm" runat="server">
                                    <asp:Button ID="ToUpdateArtist" runat="server" CssClass="btn btn-warning" Text="Update" CommandArgument='<%# Eval("ArtistID") %>' OnClick="ToUpdateArtist_Click"/>
                                    <asp:Button ID="ToDeleteArtist" runat="server" CssClass="btn btn-danger" Text="Delete" CommandArgument='<%# Eval("ArtistID") %>' OnClick="ToDeleteArtist_Click" />
                                </asp:Panel>
                          </div>
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
