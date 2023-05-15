using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using KpopZtation.Controller;
using KpopZtation.Handler;


namespace KpopZtation.Views
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NavbarController.HandleUserState();

            if ((Boolean)Session["IsUserLoggedIn"])
            {
                if(CustomerHandler.isAdmin())
                {
                    ToCartBtn.Visible = false;

                }
                else
                {
                    ToCartBtn.Visible = true;
                }
                ToHomeBtn.Visible = true;
                ToTransactionBtn.Visible = true;

                sign_in_div.Visible = false;
                ToProfileBtn.Visible = true;
                ToSignOutBtn.Visible = true;
            }
            else
            {
                ToHomeBtn.Visible = true;
                ToCartBtn.Visible = false;
                ToTransactionBtn.Visible = false;

                sign_in_div.Visible = true;
                ToProfileBtn.Visible = false;
                ToSignOutBtn.Visible = false;
            }
        }

        protected void ToHomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home.aspx");
        }

        protected void ToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SignIn/Login.aspx");
        }

        protected void ToRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SignIn/Register.aspx");

        }

        protected void ToSignOutBtn_Click(object sender, EventArgs e)
        {
            NavbarController.doSignOut();
        }
    }
}