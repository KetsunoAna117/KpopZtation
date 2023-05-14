using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class CustomerHandler
    {
        public static String checkUniqueEmail(String email)
        {
            Customer customer = CustomerRepository.findCustomerByEmail(email);
            if(customer != null)
            {
                return "Email has been already registered";
            }
            return "";

        }

        public static void insertToDatabase(string name, string email, String gender, string address, string password)
        {
            insertToDatabase(name, email, gender, address, password);
        }
    }
}