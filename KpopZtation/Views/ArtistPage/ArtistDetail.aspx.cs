﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Model;
using KpopZtation.Controller;

namespace KpopZtation.Views.Artist
{
    public partial class ArtistDetail : System.Web.UI.Page
    {
        private void updateView(int id)
        {
            if(IsPostBack == false)
            {
                List<Model.Album> albums = AlbumController.getAlbums(id);
                AlbumsGridView.DataSource = albums;
                AlbumsGridView.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");

            }

            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Model.Artist artist = ArtistController.GetArtist(id);
            ArtistImage.ImageUrl = "~/Assets/ArtistImage/" + artist.ArtistImage;
            ArtistName.Text = artist.ArtistName;

            if (CustomerController.isAdmin())
            {
                InsertAlbumBtn.Visible = true;
                AlbumsGridView.Columns[6].Visible = true;
                AlbumsGridView.Columns[7].Visible = true;
            }
            else
            {
                InsertAlbumBtn.Visible = false;
                AlbumsGridView.Columns[6].Visible = false;
                AlbumsGridView.Columns[7].Visible = false;
            }

            if (IsPostBack == false)
            {
                updateView(id);
            }
        }

        protected void InsertAlbumBtn_Click(object sender, EventArgs e)
        {
            int artistId = Convert.ToInt32(Request.QueryString["Id"]);
            Response.Redirect("~/Views/AlbumPage/InsertAlbum.aspx?id=" + artistId);
        }

        protected void AlbumsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            int albumID = Convert.ToInt32(AlbumsGridView.DataKeys[selectedIndex].Value);

            ArtistDetailController.UpdateAlbum(albumID);
        }

        protected void AlbumsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            int albumID = Convert.ToInt32(AlbumsGridView.DataKeys[selectedIndex].Value);

            String filePath = Server.MapPath("~/Assets/AlbumImage/");
            ArtistDetailController.deleteAlbum(albumID, filePath);

        }

        protected void AlbumsGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int selectedIndex = e.NewSelectedIndex;
            int id = Convert.ToInt32(AlbumsGridView.DataKeys[selectedIndex].Value);

            ArtistDetailController.SelectAlbum(id);

        }
    }
}