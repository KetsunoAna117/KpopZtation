using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Handler;
using KpopZtation.Model;

namespace KpopZtation.Views
{
    public partial class Home : System.Web.UI.Page
    {
        private void updateView()
        {
            List<Model.Artist> artists = ArtistHandler.getAllArtist();
            CardRepeater.DataSource = artists;
            CardRepeater.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User_Cookie"] == null && Session["User"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                if (CustomerHandler.isAdmin())
                {
                    InsertArtistBtn.Visible = true;
                }
                else
                {
                    InsertArtistBtn.Visible = false;
                }

                if(IsPostBack == false)
                {
                    updateView();
                }
            }
        }

        protected void InsertArtistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ArtistPage/InsertArtist.aspx");
        }

    }
}