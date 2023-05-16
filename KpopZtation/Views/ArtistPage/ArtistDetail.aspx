<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KpopZtation.Views.Artist.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .artist_details_container{
            display:flex;

        }

        .artist_details{
            margin-right: 2rem;
        }

        .Home_AlbumData{
            margin-top: 2rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Artist Details</h3>
    <div class="artist_details_container">
        <div class="artist_details">
            <div class="card text-bg-dark" style="width: 18rem;">
                <asp:Image ID="ArtistImage" runat="server" CssClass="card-img-top"/>
                <div class="card-body">
                    <asp:Label ID="ArtistName" runat="server" CssClass="card-text"></asp:Label>
                </div>
            </div>
        </div>

        <div class="artist_albums">
            <asp:Button ID="InsertAlbumBtn" runat="server" Text="Insert Albums" CausesValidation="false" CssClass="btn btn-success" OnClick="InsertAlbumBtn_Click"/>
            <div class="Home_AlbumData">
                <asp:GridView ID="AlbumsGridView" CssClass="table table-dark table-striped" runat="server" AutoGenerateColumns="False" OnRowDeleting="AlbumsGridView_RowDeleting" OnRowUpdating="AlbumsGridView_RowUpdating" DataKeyNames="AlbumID" OnSelectedIndexChanging="AlbumsGridView_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="AlbumID" HeaderText="ID" SortExpression="AlbumID" Visible="false"/>
                        <asp:ButtonField CommandName="Select" HeaderText="Select" ShowHeader="True" Text="Details" />
                          <asp:ImageField DataImageUrlField="AlbumImage" DataImageUrlFormatString="~/Assets/AlbumImage/{0}" HeaderText="Artist Image" ControlStyle-Height="200px" ControlStyle-CssClass="object-fit-contain border rounded">
                            <ControlStyle CssClass="object-fit-contain border rounded" Height="200px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="AlbumName" HeaderText="Album Name" SortExpression="AlbumName" />
                        <asp:BoundField DataField="AlbumPrice" HeaderText="Album Price" SortExpression="AlbumPrice" />
                        <asp:BoundField DataField="AlbumDescription" HeaderText="Album Description" SortExpression="AlbumDescription" />
                        <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Update" ShowHeader="True" Text="Update" ControlStyle-CssClass="btn btn-outline-warning">
<ControlStyle CssClass="btn btn-outline-warning"></ControlStyle>
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete" ControlStyle-CssClass="btn btn-outline-danger">
<ControlStyle CssClass="btn btn-outline-danger"></ControlStyle>
                        </asp:ButtonField>

                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
