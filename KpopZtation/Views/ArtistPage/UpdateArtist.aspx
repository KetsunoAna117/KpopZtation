<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="KpopZtation.Views.Artist.UpdateArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .update_artist_container{
            display:flex;
        }

        .artist_details{
            margin-right: 2rem;
        }

        .SubmitBtn{
            margin-top: 1rem;
        }

        .InsertArtist_InputField > *:not(:last-child){
            margin-top: 1rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Artist</h2>
    <div class="update_artist_container">
        <div class="artist_details">
            <div class="card" style="width: 18rem;">
                <asp:Image ID="ArtistImage" runat="server" CssClass="card-img-top"/>
                <div class="card-body">
                    <asp:Label ID="ArtistName" runat="server" CssClass="card-text"></asp:Label>
                </div>
            </div>
        </div>

     <asp:Panel ID="InsertArtist_InputField" runat="server" CssClass="InsertArtist_InputField">
        <asp:Panel ID="InsertArtist_NameInput" runat="server" CssClass="input_field">
            <asp:Label ID="Label1" runat="server" Text="Artist Name"></asp:Label>
            <asp:TextBox ID="ArtistNameTxt" runat="server"></asp:TextBox>
            <asp:Label ID="ArtistNameError" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="InsertArtist_ImageInput" runat="server" CssClass="input_field">
            <asp:Label ID="Label2" runat="server" Text="Artist Image"></asp:Label>
            <asp:FileUpload ID="ArtistImageUpload" runat="server" />
            <asp:Label ID="ArtistImageError" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>

        <asp:Button CssClass="btn btn btn-outline-success SubmitBtn" ID="SubmitBtn" runat="server" Text="Update Artist" OnClick="SubmitBtn_Click"/>
    </asp:Panel>
    </div>

</asp:Content>
