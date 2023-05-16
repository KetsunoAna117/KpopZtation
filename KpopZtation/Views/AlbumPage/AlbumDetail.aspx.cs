using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;

namespace KpopZtation.Views.Album
{
    public partial class AlbumDetail : System.Web.UI.Page
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
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User_Cookie"] == null && Session["User"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            if (CustomerController.isAdmin() == false)
            {
                AddToCart_div.Visible = true;
            }
            else
            {
                AddToCart_div.Visible = false;

            }

            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");

            }

            if(IsPostBack == false)
            {
                showData();
            }
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            String quantity = AddToCartTxt.Text.ToString();

            BuyQuantityError.Text = AlbumDetailController.CheckQuantity(id, quantity);
        }
    }
}