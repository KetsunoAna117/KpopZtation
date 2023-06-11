<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateAlbum.aspx.cs" Inherits="KpopZtation.Views.Albums.UpdateAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .update_album_container{
            display:flex;
        }

        .album_details{
            margin-right: 2rem;
        }

        .SubmitBtn{
            margin-top: 1rem;
        }

        .InsertAlbum_InputField > *:not(:last-child){
            margin-top: 1rem;
        }

        .InsertAlbum_InputField{
            width: 27vw;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-3">Update Album</h2>
    <div class="update_album_container">
        <div class="album_details">
            <div class="card text-bg-dark" style="width: 18rem;">
              <asp:Image ID="AlbumImage" runat="server" CssClass="card-img-top"/>
                <div class="card-body d-flex flex-column">
                    <asp:Label ID="AlbumName" runat="server" CssClass="card-title fw-bold"></asp:Label>
                    <asp:Label ID="AlbumDescription" runat="server" CssClass="card-text"></asp:Label>
                </div>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item d-flex justify-content-between">
                        <asp:Label ID="AlbumPriceLbl" runat="server" Text="Album Price" CssClass="fw-bold"></asp:Label>
                        <asp:Label ID="AlbumPrice" runat="server"></asp:Label>                        
                    </li>
                    <li class="list-group-item d-flex justify-content-between">
                        <asp:Label ID="AlbumStockLbl" runat="server" Text="Album Stock" CssClass="fw-bold "></asp:Label>
                        <asp:Label ID="AlbumStock" runat="server"></asp:Label>                        
                    </li>
                </ul>
            </div>
        </div>

        <asp:Panel ID="InsertAlbum_InputField" runat="server" CssClass="InsertAlbum_InputField d-flex flex-column">
            <asp:Panel ID="InsertAlbum_NameInput" runat="server" CssClass="input_field">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Album Name"></asp:Label>
                    <asp:TextBox ID="AlbumNameTxt" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="AlbumNameError" runat="server" ForeColor="Red"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="InsertAlbum_DescriptionInput" runat="server" CssClass="input_field ">
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

            <asp:Button CssClass="btn btn btn-outline-success SubmitBtn" ID="SubmitBtn" runat="server" Text="Update Album" OnClick="SubmitBtn_Click"/>
        </asp:Panel>

    </div>
</asp:Content>
