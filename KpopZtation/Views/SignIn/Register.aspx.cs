using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;

namespace KpopZtation.Views.SignIn
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null || Request.Cookies["User_Cookie"] != null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String name = NameTxt.Text.ToString();
            String email = EmailTxt.Text.ToString();
            Boolean male = GenderMaleBtn.Checked;
            Boolean female = GenderFemaleBtn.Checked;
            String address = AddressTxt.Text.ToString();
            String password = PasswordTxt.Text.ToString();

            NameError.Text = RegisterController.checkName(name);
            EmailError.Text = RegisterController.checkEmail(email);
            GenderError.Text = RegisterController.checkGender(male, female);
            AddressError.Text = RegisterController.checkAddress(address);
            PasswordError.Text = RegisterController.checkPassword(password);

            if(NameError.Text == "" && EmailError.Text == "" && GenderError.Text == "" && AddressError.Text == "" && PasswordError.Text == "")
            {
                Response.Redirect("~/Views/SignIn/Login.aspx");
                RegisterController.InsertToDatabase(name, email, male, female, address, password);
                SuccessLbl.Text = "Success!";
            }
            else
            {
                SuccessLbl.Text = "";

            }

        }
    }
}