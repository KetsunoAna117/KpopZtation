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
    public partial class Cart : System.Web.UI.Page
    {
        private void showData(int customerID)
        {
            CartGridView.DataSource = CartController.GetShowedCartDatas(customerID);
            CartGridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // if guest account
            if (Request.Cookies["User_Cookie"] == null && Session["User"] == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            // if admin
            if (CustomerController.isAdmin() == true)
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            Customer customer = CustomerController.GetLoggedInUser();
            // double check
            if (customer == null)
            {
                Response.Redirect("~/Views/Home.aspx");

            }

            if (IsPostBack == false)
            {
                showData(customer.CustomerID);
            }
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            Customer customer = CustomerController.GetLoggedInUser();
            CartController.CheckOut(customer.CustomerID);
        }
    }
}