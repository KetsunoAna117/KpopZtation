using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class TransactionDetailRepository
    {
        private static Database1Entities5 db = Singleton.getDb();
        public static void insertTransactionDetail(int transactionID, int albumID, int quantity)
        {
            db.TransactionDetails.Add(TransactionDetailFactory.createTransactionDetail(transactionID, albumID, quantity));
            db.SaveChanges();
        }

        public static void deleteTransactionDetail(int transactionID)
        {
            TransactionDetail selectedTd = db.TransactionDetails.Find(transactionID);
            db.TransactionDetails.Remove(selectedTd);
            db.SaveChanges();

        }

        public static dynamic getAllTransactionDetail(Customer customer)
        {
            return db.TransactionDetails.Join(db.TransactionHeaders,
                td => td.TransactionID,
                th => th.TransactionID,
                (td, th) => new { td, th }).Join(db.Albums,
                transaction => transaction.td.AlbumID,
                album => album.AlbumID,
                (transaction, album) => new
                {
                    TransactionID = transaction.td.TransactionID,
                    CustomerID = customer.CustomerID,
                    TransactionDate = transaction.th.TransactionDate,
                    CustomerName = customer.CustomerName,
                    Courier = "KPOPZstation Courier",
                    AlbumImage = album.AlbumImage,
                    AlbumName = album.AlbumName,
                    Quantity = transaction.td.Qty,
                    AlbumPrice = album.AlbumPrice
                }).Where(c => c.CustomerID == customer.CustomerID).ToList();
        }

    }
}