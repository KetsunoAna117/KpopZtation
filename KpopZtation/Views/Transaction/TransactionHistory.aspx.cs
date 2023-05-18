using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Model;
using KpopZtation.Handler;

namespace KpopZtation.Views.Transaction
{

    public partial class TransactionHistory : System.Web.UI.Page
    {
        private void showData(int customerID)
        {
            List<TransactionHandler.ShowedTransactionData> datas = TransactionHistoryController.GetTransactionDatas(customerID);
            TransactionHistoryGridView.DataSource = datas;
            TransactionHistoryGridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Customer currentUser = CustomerController.GetLoggedInUser();
            if (CustomerController.isAdmin() || CustomerController.IsUserLoggedIn() == false || currentUser == null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }

            if(IsPostBack == false)
            {
                showData(currentUser.CustomerID);
            }
        }
    }
}