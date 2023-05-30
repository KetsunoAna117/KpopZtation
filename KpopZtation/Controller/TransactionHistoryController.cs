using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;
using KpopZtation.Model;

namespace KpopZtation.Controller
{
    public class TransactionHistoryController
    {
        public static dynamic GetTransactionDatas(Customer currentUser)
        {
            return TransactionHandler.GetTransactionHistory(currentUser);
        }
    }
}