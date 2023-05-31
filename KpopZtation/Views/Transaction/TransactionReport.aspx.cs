using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Model;

namespace KpopZtation.Views.Transaction
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer currentUser = CustomerController.GetLoggedInUser();
            if (CustomerController.isAdmin() == false || CustomerController.IsUserLoggedIn() == false || currentUser == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }
    }
}