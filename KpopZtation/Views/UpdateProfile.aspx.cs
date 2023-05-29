using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Model;
using KpopZtation.Controller;

namespace KpopZtation.Views
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private void setGender(Customer customer)
        {
            if(customer.CustomerGender == "Male")
            {
                GenderMaleBtn.Checked = true;
                GenderFemaleBtn.Checked = false;
            }
            else
            {
                GenderMaleBtn.Checked = false;
                GenderFemaleBtn.Checked = true;
            }
        }
        private void showData(Customer customer)
        {
            cardName.Text = customer.CustomerName;
            cardEmail.Text = customer.CustomerEmail;
            cardGender.Text = customer.CustomerGender;
            cardAddress.Text = customer.CustomerAddress;

            NameTxt.Text = customer.CustomerName;
            setGender(customer);
            EmailTxt.Text = customer.CustomerEmail;
            AddressTxt.Text = customer.CustomerAddress;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer = CustomerController.GetLoggedInUser();

            if (customer == null)
            {
                Response.Redirect("~/Views/Home.aspx");

            }

            if(IsPostBack == false)
            {
                showData(customer);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
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

            Customer customer = CustomerController.GetLoggedInUser();


            if (NameError.Text == "" && EmailError.Text == "" && GenderError.Text == "" && AddressError.Text == "" && PasswordError.Text == "")
            {
                RegisterController.UpdateToDatabase(customer.CustomerID, name, email, male, female, address, password, customer.CustomerRole);
                Response.Redirect("~/Views/Home.aspx");
            }
        }
    }
}