using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader createTransactionHeader(DateTime date, int customerID)
        {
            return new TransactionHeader()
            {
                TransactionDate = date,
                CustomerID = customerID
            };
        }
    }
}