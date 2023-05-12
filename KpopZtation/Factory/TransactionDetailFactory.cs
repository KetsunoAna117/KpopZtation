using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail createTransactionDetail(int transactionID, int albumID, int quantity)
        {
            return new TransactionDetail()
            {
                TransactionID = transactionID,
                AlbumID = albumID,
                Qty = quantity
            };
        }
    }
}