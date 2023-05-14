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
        
        public static String validateLogin(String email, String password)
        {
            Customer customer = CustomerRepository.getCustomer(email, password);
            if(customer == null)
            {
                return "Email or Password Invalid";
            }
            return "";
        }

        public static void insertToDatabase(string name, string email, string gender, string address, string password, string role)
        {
            CustomerRepository.insertCustomer(name, email, password, gender, address, role);
        }
    }
}