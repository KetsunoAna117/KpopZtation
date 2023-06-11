using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;
using KpopZtation.Model;

namespace KpopZtation.Controller
{
    public class TransactionController
    {
        public static List<TransactionHeader> GetTransactionReport()
        {
            return TransactionHandler.GetTransactionReport();
        }
    }
}