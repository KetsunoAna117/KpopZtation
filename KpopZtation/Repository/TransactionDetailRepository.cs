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
        private static Database1Entities2 db = Singleton.getDb();
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

        public static TransactionDetail getTransactionDetail(int transactionID)
        {
            return db.TransactionDetails.Find(transactionID);
        }

    }
}