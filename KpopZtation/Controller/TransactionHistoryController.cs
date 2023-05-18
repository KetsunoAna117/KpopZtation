using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;

namespace KpopZtation.Controller
{
    public class TransactionHistoryController
    {
        public static List<TransactionHandler.ShowedTransactionData> GetTransactionDatas(int customerID)
        {
            return TransactionHandler.GetTransactionHistory(customerID);
        }
    }
}