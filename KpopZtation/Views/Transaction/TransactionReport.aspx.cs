using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Controller;
using KpopZtation.Model;
using KpopZtation.Report;
using KpopZtation.Dataset;

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
            
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;

            //int id = (int)Session["Admin"];
            DataSet1 data = loadDetailData(TransactionController.GetTransactionReport());
            report.SetDataSource(data);
        }

        private DataSet1 loadDetailData(List<TransactionHeader> transactions)
        {
            DataSet1 newData = new DataSet1();
            var headerTable = newData.TrHeader;
            var detailTable = newData.TrDetail;

            foreach (TransactionHeader tr in transactions)
            {
                int grandtotalvalue = 0;
                var row = headerTable.NewRow();

                headerTable.Rows.Add(row);

                foreach (TransactionDetail detail in tr.TransactionDetails)
                {

                    //Album album = AlbumRepository.getAlbum(detail.AlbumID);
                    Album album = AlbumController.getAnAlbum(detail.AlbumID);
                    int albumprice = Convert.ToInt32(album.AlbumPrice);

                    int subtotalvalue = Convert.ToInt32(albumprice * Convert.ToInt32(detail.Qty));

                    var drow = detailTable.NewRow();
                    drow["TransactionId"] = detail.TransactionID;
                    drow["AlbumName"] = album.AlbumName;
                    drow["Quantity"] = detail.Qty;
                    drow["AlbumPrice"] = albumprice;
                    drow["SubTotalValue"] = subtotalvalue;
                    detailTable.Rows.Add(drow);

                    grandtotalvalue += subtotalvalue;
                }

                row["TransactionId"] = tr.TransactionID;
                row["CustomerId"] = tr.CustomerID;
                row["TransactionDate"] = tr.TransactionDate;
                row["GrandTotalValue"] = grandtotalvalue;
            }

            return newData;
        }
    }
}