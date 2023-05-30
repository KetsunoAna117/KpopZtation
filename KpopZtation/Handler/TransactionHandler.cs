using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class TransactionHandler
    {
        //public class ShowedTransactionData
        //{
        //    public int TransactionID { get; set; }
        //    public DateTime TransactionDate { get; set; }
        //    public String CustomerName { get; set; }
        //    public String Courier { get; set; }
        //    public String AlbumImage { get; set; }
        //    public String AlbumName { get; set; }
        //    public int Quantity { get; set; }
        //    public int AlbumPrice { get; set; }

        //}

        //public static ShowedTransactionData createShowedTransactionData(int id, DateTime date, string customerName, string courier, string albumImage, string albumName, int quantity, int albumPrice)
        //{
        //    return new ShowedTransactionData(){
        //        TransactionID = id,
        //        TransactionDate = date,
        //        CustomerName = customerName,
        //        Courier = courier,
        //        AlbumImage = albumImage,
        //        AlbumName = albumName,
        //        Quantity = quantity,
        //        AlbumPrice = albumPrice
        //    };
        //}

        //public static List<ShowedTransactionData> GetTransactionHistory(int customerID)
        //{
        //    Customer customer = CustomerRepository.GetCustomer(customerID);

        //    List<TransactionHeader> transactionHeaders = TransactionHeaderRepository.getAllTransactionHeader().Where(th => th.CustomerID == customerID).ToList();

        //    List<TransactionDetail> transactionDetails = TransactionDetailRepository.getAllTransactionDetail().Where(td => transactionHeaders.Any(th => th.TransactionID == td.TransactionID)).ToList();

        //    List<ShowedTransactionData> transactionDatas = new List<ShowedTransactionData>();

        //    foreach(TransactionHeader th in transactionHeaders)
        //    {
        //        foreach(TransactionDetail td in transactionDetails)
        //        {
        //            Album a = AlbumRepository.getAlbum(td.AlbumID);

        //            ShowedTransactionData data = createShowedTransactionData(th.TransactionID, th.TransactionDate, customer.CustomerName, "KPOZstation Courier", a.AlbumImage, a.AlbumName, td.Qty, a.AlbumPrice);

        //            transactionDatas.Add(data);

        //        }
        //    }


        //    return transactionDatas;
        //}

        //public static List<ShowedTransactionData> GetTransactionHistory(int customerID)
        //{
        //    Customer customer = CustomerRepository.GetCustomer(customerID);

        //    List<TransactionHeader> transactionHeaders = TransactionHeaderRepository.getAllTransactionHeader().Where(th => th.CustomerID == customerID).ToList();


        //    List<ShowedTransactionData> transactionDatas = new List<ShowedTransactionData>();

        //    foreach (TransactionHeader th in transactionHeaders)
        //    {
        //        List<TransactionDetail> transactionDetails = TransactionDetailRepository.getAllTransactionDetail().Where(td => td.TransactionID == th.TransactionID).ToList();

        //        foreach (TransactionDetail td in transactionDetails)
        //        {
        //            Album a = AlbumRepository.getAlbum(td.AlbumID);

        //            ShowedTransactionData data = createShowedTransactionData(th.TransactionID, th.TransactionDate, customer.CustomerName, "KPOZstation Courier", a.AlbumImage, a.AlbumName, td.Qty, a.AlbumPrice);

        //            transactionDatas.Add(data);

        //        }
        //    }


        //    return transactionDatas;
        //}

        public static dynamic GetTransactionHistory(Customer currentUser)
        {
            return TransactionDetailRepository.getAllTransactionDetail(currentUser);
        }

    }
}