<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KpopZtation.Views.Artist.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .artist_details_container{
            display:flex;

        }

        .artist_details{
            margin-right: 2rem;
        }

        .linkButton_Card{
            text-decoration: none;
        }

        .Home_ArtistData{
            margin-top: 2rem;
        }

        .album_image{
            justify-self: center;
        }

        .Home_ArtistDatarow{
            overflow-x: auto;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Artist Details</h3>
    <div class="artist_details_container">
        <div class="artist_details">
            <div class="card bg-dark" style="width: 18rem;">
                <asp:Image ID="ArtistImage" runat="server" CssClass="card-img-top"/>
                <div class="card-body">
                    <asp:Label ID="ArtistName" runat="server" CssClass="card-title text-light"></asp:Label>
                </div>
            </div>
        </div>

        <div class="artist_albums">
            <asp:Button ID="InsertAlbumBtn" runat="server" Text="Insert Albums" CausesValidation="false" CssClass="btn btn-success mb-4" OnClick="InsertAlbumBtn_Click"/>
            <h3>List Albums</h3>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater ID="AlbumCardRepeater" runat="server" OnItemDataBound="AlbumCardRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card h-100 bg-dark">
                                <asp:LinkButton ID="Card" runat="server" CssClass="text-decoration-none" OnClick="Card_Click" CommandArgument='<%# Eval("AlbumID") %>'>
                                    <img src="../../Assets/AlbumImage/<%# Eval("AlbumImage") %>" class="card-img-top" alt="...">
                                    <div class="card-body">
                                        <h5 class="card-title text-light"><%# Eval("AlbumName") %></h5>
                                        <p class="card-text text-light"><%# Eval("AlbumDescription") %></p>

                                          <ul class="list-group list-group-flush">
                                            <li class="list-group-item bg-dark">
                                                <div class="d-flex justify-content-between">
                                                    <p class="card-text text-light fw-bold">Album Price</p>
                                                    <p class="card-text text-light"><%# Eval("AlbumPrice") %></p>
                                                </div>
                                            </li>
                                          </ul>

                                        <div class="card-footer">
                                            <asp:Panel ID="ActionBtn" CssClass="btn-group btn-group-sm" runat="server">
                                                <asp:Button ID="ToUpdateAlbum" runat="server" CssClass="btn btn-warning" Text="Update" CommandArgument='<%# Eval("AlbumID") %>' OnClick="ToUpdateAlbum_Click"/>
                                                <asp:Button ID="ToDeleteAlbum" runat="server" CssClass="btn btn-danger" Text="Delete" CommandArgument='<%# Eval("AlbumID") %>' OnClick="ToDeleteAlbum_Click" />
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

<%--        <div class="card-group overflow-scroll">
                <asp:Repeater ID="AlbumCardRepeater" runat="server" OnItemDataBound="AlbumCardRepeater_ItemDataBound">
                    <ItemTemplate>
                        <asp:LinkButton ID="Card" runat="server" CssClass="linkButton_Card mt-4 me-3 bg-dark card h-100" OnClick="Card_Click" CommandArgument='<%# Eval("ArtistID") %>'>
                            <img src="../../Assets/AlbumImage/<%# Eval("AlbumImage") %>" class="card-img-top" style="width: 30rem; height: 24rem; object-fit: cover" alt="...">
                            <div class="card-body text-light" style="width: 30rem;">
                                <h5 class="card-title"><%# Eval("AlbumName") %></h5>
                                <p class="card-text"><%# Eval("AlbumDescription") %></p>
                                <asp:Panel ID="ActionBtn" CssClass="btn-group btn-group-sm" runat="server">
                                    <asp:Button ID="ToUpdateAlbum" runat="server" CssClass="btn btn-warning" Text="Update" CommandArgument='<%# Eval("ArtistID") %>' OnClick="ToUpdateAlbum_Click"/>
                                    <asp:Button ID="ToDeleteAlbum" runat="server" CssClass="btn btn-danger" Text="Delete" CommandArgument='<%# Eval("ArtistID") %>' OnClick="ToDeleteAlbum_Click" />
                                </asp:Panel>
                          </div>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>--%>

<%--        <div class="Home_AlbumData">
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
            </div>--%>
        </div>
    </div>

</asp:Content>
