using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Handler;

namespace KpopZtation.Views.SignIn
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null || Request.Cookies["User_Cookie"] != null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            String email = EmailTxt.Text.ToString();
            String password = PasswordTxt.Text.ToString();

            EmailError.Text = LoginController.CheckEmail(email);
            PasswordTxt.Text = LoginController.CheckPassword(password);
            ErrorLogin.Text = LoginController.CheckLogin(email, password);

            if (EmailError.Text == "" && PasswordTxt.Text == "" && ErrorLogin.Text == "")
            {
                LoginController.doLogin(email, password, CheckBoxRememberMe.Checked);
            }
        }
    }
}