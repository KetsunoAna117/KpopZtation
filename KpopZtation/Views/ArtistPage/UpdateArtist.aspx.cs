using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using System.IO;

namespace KpopZtation.Views.Artist
{
    public partial class UpdateArtist : System.Web.UI.Page
    {
        private void showData()
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Model.Artist artist = ArtistController.GetArtist(id);
            ArtistImage.ImageUrl = "~/Assets/ArtistImage/" + artist.ArtistImage;
            ArtistName.Text = artist.ArtistName;

            ArtistNameTxt.Text = artist.ArtistName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User_Cookie"] == null && Session["User"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            if (CustomerController.isAdmin() == false)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");

            }

            if (IsPostBack == false)
            {
                showData();
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Model.Artist artist = ArtistController.GetArtist(id);

            String name = ArtistNameTxt.Text.ToString();
            ArtistNameError.Text = ArtistController.checkArtistName(name);
            ArtistImageError.Text = ArtistController.CheckFile(ArtistImageUpload);

            if (ArtistNameError.Text == "" && ArtistImageError.Text == "")
            {
                ArtistController.UpdateArtist(artist, name, ArtistImageUpload);
            }

        }
    }
}