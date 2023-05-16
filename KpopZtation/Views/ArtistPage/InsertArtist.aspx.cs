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

            if (Request.Cookies["User_Cookie"] == null && Session["User"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
            
            if (CustomerController.isAdmin() == false)
            {
                Response.Redirect("~/Views/Home.aspx");
            }

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            String name = ArtistNameTxt.Text.ToString();
            ArtistNameError.Text = ArtistController.checkArtistName(name);


            if (ArtistImageUpload.HasFile)
            {
                ArtistImageError.Text = ArtistController.checkFile(Path.GetExtension(ArtistImageUpload.FileName).ToLower(), ArtistImageUpload.FileBytes.Length);

                if(ArtistImageError.Text == "" && ArtistNameError.Text == "")
                {
                    string fileName = ArtistImageUpload.FileName;
                    string filePath = Server.MapPath("~/Assets/ArtistImage/") + fileName;

                    ArtistImageUpload.SaveAs(filePath);

                    ArtistHandler.insertArtist(name, fileName);
                    Response.Redirect("~/Views/Home.aspx");
                }
                else
                {
                    return;
                }
            }
            else
            {
                ArtistImageError.Text = "Must be chosen";
            }
            
        }
    }
}