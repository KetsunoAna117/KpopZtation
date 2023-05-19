using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Model;

namespace KpopZtation.Views
{
    public partial class Home : System.Web.UI.Page
    {
        private void updateView()
        {
            List<Model.Artist> artists = ArtistController.getAllArtist();
            CardRepeater.DataSource = artists;
            CardRepeater.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (CustomerController.isAdmin())
            //{
            //    InsertArtistBtn.Visible = true;
            //    GridView1.Columns[3].Visible = true;
            //    GridView1.Columns[4].Visible = true;
            //}
            //else
            //{
            //    InsertArtistBtn.Visible = false;
            //    GridView1.Columns[3].Visible = false;
            //    GridView1.Columns[4].Visible = false;
            //}

            if (!IsPostBack)
            {
                updateView();
            }
        }

        protected void InsertArtistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ArtistPage/InsertArtist.aspx");
        }

        //protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    int selectedIndex = e.NewSelectedIndex;
        //    int id = Convert.ToInt32(GridView1.DataKeys[selectedIndex].Value);

        //    HomeController.SelectArtist(id);
            

        //}

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int selectedIndex = e.RowIndex;
        //    int id = Convert.ToInt32(GridView1.DataKeys[selectedIndex].Value);

        //    HomeController.UpdateArtist(id);

        //}

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int selectedIndex = e.RowIndex;
        //    int id = Convert.ToInt32(GridView1.DataKeys[selectedIndex].Value);
        //    String filePath = Server.MapPath("~/Assets/ArtistImage/");

        //    HomeController.deleteArtist(id, filePath);
        //}
    }
}