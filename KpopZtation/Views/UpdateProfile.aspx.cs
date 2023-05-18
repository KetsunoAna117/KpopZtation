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
        private void showData()
        {
            Customer customer = CustomerController.GetLoggedInUser();
            cardName.Text = customer.CustomerName;
            cardEmail.Text = customer.CustomerEmail;
            cardGender.Text = customer.CustomerGender;
            cardAddress.Text = customer.CustomerAddress;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController.loadCookie();
            if (Request.Cookies["User_Cookie"] == null && Session["User"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
            else if(Request.Cookies["User_Cookie"] != null)
            {

            }

            if(IsPostBack == false)
            {
                showData();
            }
        }
    }
}