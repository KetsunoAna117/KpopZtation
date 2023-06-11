using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;


namespace KpopZtation.Views.Albums
{
    public partial class UpdateAlbum : System.Web.UI.Page
    {

        private void showData()
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Model.Album album = AlbumController.getAnAlbum(id);

            AlbumImage.ImageUrl = "~/Assets/AlbumImage/" + album.AlbumImage;
            AlbumName.Text = album.AlbumName;
            AlbumDescription.Text = album.AlbumDescription;
            AlbumPrice.Text = album.AlbumPrice.ToString();
            AlbumStock.Text = album.AlbumStock.ToString();

            AlbumNameTxt.Text = album.AlbumName;
            AlbumDescTxt.Text = album.AlbumDescription;
            AlbumPriceTxt.Text = album.AlbumPrice.ToString();
            AlbumStockTxt.Text = album.AlbumStock.ToString();
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
            Model.Album album = AlbumController.getAnAlbum(id);

            String name = AlbumNameTxt.Text.ToString();
            String desc = AlbumDescTxt.Text.ToString();
            String price = AlbumPriceTxt.Text.ToString();
            String stock = AlbumStockTxt.Text.ToString();
            int artistID = album.ArtistID;

            AlbumNameError.Text = AlbumController.CheckName(name);
            AlbumDescError.Text = AlbumController.CheckDescription(desc);
            AlbumPriceError.Text = AlbumController.CheckPrice(price);
            AlbumStockError.Text = AlbumController.CheckStock(stock);
            AlbumImageError.Text = AlbumController.CheckFile(AlbumImageUpload);

            if (AlbumImageError.Text == "" && AlbumNameError.Text == "" && AlbumDescError.Text == "" && AlbumPriceError.Text == "" && AlbumStockError.Text == "")
            {

                AlbumController.UpdateAlbum(id, artistID, name, AlbumImageUpload, Convert.ToInt32(price), Convert.ToInt32(stock), desc);
            }

            //// Validate File (Can't move to controller)
            //if (AlbumImageUpload.HasFile)
            //{
            //    AlbumImageError.Text = ArtistController.ValidateFile(Path.GetExtension(AlbumImageUpload.FileName).ToLower(), AlbumImageUpload.FileBytes.Length);

            //    if (AlbumImageError.Text == "" && AlbumNameError.Text == "" && AlbumDescError.Text == "" && AlbumPriceError.Text == "" && AlbumStockError.Text == "")
            //    {
            //        string fileName = AlbumImageUpload.FileName;
            //        string filePath = Server.MapPath("~/Assets/AlbumImage/") + fileName;

            //        AlbumImageUpload.SaveAs(filePath);

            //        AlbumController.UpdateAlbum(id, artistID, name, fileName, Convert.ToInt32(price), Convert.ToInt32(stock), desc);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    AlbumImageError.Text = "Must be chosen";
            //}

        }
    }
}