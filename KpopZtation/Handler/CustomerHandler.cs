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
        
        public static Customer ValidateEmail(String email)
        {
            List<Customer> customers = CustomerRepository.getAllCustomer();
            return customers.Find(customer => customer.CustomerEmail == email);
        }

        public static Customer ValidateLogin(String email, String password)
        {
            List<Customer> customers = CustomerRepository.getAllCustomer();
            return customers.Find(customer => customer.CustomerEmail == email && customer.CustomerPassword == password);

        }

        public static Customer getCustomer(int id)
        {
            List<Customer> customers = CustomerRepository.getAllCustomer();
            return customers.Find(customer => customer.CustomerID == id);
        }

        //public static bool isAdmin()
        //{
        //    Customer loggedInUser = GetLoggedInUser();
        //    return loggedInUser != null && loggedInUser.CustomerRole.ToString() == "ADMIN";
        //}




    }
}