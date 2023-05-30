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
            return CustomerRepository.findCustomerByEmail(email);
        }

        public static Customer ValidateLogin(String email, String password)
        {
            return CustomerRepository.GetCustomer(email, password);

        }

        public static Customer getCustomer(int id)
        {
            return CustomerRepository.getCustomerByID(id);
        }

        //public static bool isAdmin()
        //{
        //    Customer loggedInUser = GetLoggedInUser();
        //    return loggedInUser != null && loggedInUser.CustomerRole.ToString() == "ADMIN";
        //}




    }
}