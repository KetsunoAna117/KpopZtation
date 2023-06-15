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
        private static Database1Entities6 db = Singleton.getDb();

        public static int insertTransactionHeader(DateTime date, int customerID)
        {
            TransactionHeader th = TransactionHeaderFactory.createTransactionHeader(date, customerID);

            db.TransactionHeaders.Add(th);
            db.SaveChanges();

            // should return newly created transactionHeaderID here
            return th.TransactionID;
        }

        public static void deleteTransactionHeader(int transactionID)
        {
            TransactionHeader selectedTh = db.TransactionHeaders.Find(transactionID);
            db.TransactionHeaders.Remove(selectedTh);
            db.SaveChanges();

        }

        public static List<TransactionHeader> getAllTransactionHeader()
        {
            return db.TransactionHeaders.ToList();
        }


    }
}