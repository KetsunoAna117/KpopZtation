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
            if(Request.QueryString["Id"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");

            }

            if(IsPostBack == false)
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


            if (ArtistImageUpload.HasFile)
            {
                String fileExtension = Path.GetExtension(ArtistImageUpload.FileName).ToLower();
                int fileSize = ArtistImageUpload.FileBytes.Length;

                ArtistImageError.Text = ArtistController.checkFile(fileExtension, fileSize);

                if (ArtistImageError.Text == "")
                {
                    String filePath = Server.MapPath("~/Assets/ArtistImage/") + artist.ArtistImage;
                    HomeController.DeleteFile(filePath);

                    String fileName = ArtistImageUpload.FileName;
                    filePath = Server.MapPath("~/Assets/ArtistImage/") + fileName;

                    ArtistImageUpload.SaveAs(filePath);

                    ArtistController.updateArtist(id, name, fileName);
                    Response.Redirect("~/Views/Home.aspx");
                }
            }
            else
            {
                ArtistImageError.Text = "Must be chosen";
            }

        }
    }
}