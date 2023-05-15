using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Handler;

namespace KpopZtation.Views.Artist
{
    public partial class InsertArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CustomerHandler.isAdmin() == false)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            String name = ArtistNameTxt.Text.ToString();
            ArtistNameError.Text = InsertArtistController.checkArtistName(name);


            if (ArtistImageUpload.HasFile)
            {
                ArtistImageError.Text = InsertArtistController.checkFile(Path.GetExtension(ArtistImageUpload.FileName).ToLower(), ArtistImageUpload.FileBytes.Length);

                if(ArtistImageError.Text == "")
                {
                    string fileName = ArtistImageUpload.FileName;
                    string filePath = Server.MapPath("~/Assets/") + fileName;

                    ArtistImageUpload.SaveAs(filePath);

                    ArtistHandler.insertArtist(name, fileName);
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