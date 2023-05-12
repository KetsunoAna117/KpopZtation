using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class TransactionHeaderRepository
    {
        private static Database1Entities2 db = Singleton.getDb();

        public static void insertTransactionHeader(DateTime date, int customerID)
        {
            db.TransactionHeaders.Add(TransactionHeaderFactory.createTransactionHeader(date, customerID));
            db.SaveChanges();
        }

        public static void deleteTransactionHeader(int transactionID)
        {
            TransactionHeader selectedTh = db.TransactionHeaders.Find(transactionID);
            db.TransactionHeaders.Remove(selectedTh);
            db.SaveChanges();

        }

        public static TransactionHeader getTransactionHeader(int transactionID)
        {
            return db.TransactionHeaders.Find(transactionID);
        }

        public static List<TransactionHeader> getAllTransactionHeader()
        {
            return (from transactionHeader in db.TransactionHeaders select transactionHeader).ToList();
        }


    }
}