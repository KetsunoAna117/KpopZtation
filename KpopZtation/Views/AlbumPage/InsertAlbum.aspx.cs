using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using System.IO;

namespace KpopZtation.Views.Album
{
    public partial class InsertAlbum : System.Web.UI.Page
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
            String name = AlbumNameTxt.Text.ToString();
            String desc = AlbumDescTxt.Text.ToString();
            String price = AlbumPriceTxt.Text.ToString();
            String stock = AlbumStockTxt.Text.ToString();
            int id = Convert.ToInt32(Request.QueryString["Id"]);

            AlbumNameError.Text = AlbumController.CheckName(name);
            AlbumDescError.Text = AlbumController.CheckDescription(desc);
            AlbumPriceError.Text = AlbumController.CheckPrice(price);
            AlbumStockError.Text = AlbumController.CheckStock(stock);

            // Validate File (Can't move to controller)
            if (AlbumImageUpload.HasFile)
            {
                AlbumImageError.Text = ArtistController.checkFile(Path.GetExtension(AlbumImageUpload.FileName).ToLower(), AlbumImageUpload.FileBytes.Length);

                if (AlbumImageError.Text == "" && AlbumNameError.Text == "" && AlbumDescError.Text == "" && AlbumPriceError.Text == "" && AlbumStockError.Text == "")
                {
                    string fileName = AlbumImageUpload.FileName;
                    string filePath = Server.MapPath("~/Assets/AlbumImage/") + fileName;

                    AlbumImageUpload.SaveAs(filePath);

                    AlbumController.insertAlbum(name, id, desc, Convert.ToInt32(price), Convert.ToInt32(stock), fileName);
                    Response.Redirect("~/Views/Home.aspx");
                }
                else
                {
                    return;
                }
            }
            else
            {
                AlbumImageError.Text = "Must be chosen";
            }
        }
    }
}