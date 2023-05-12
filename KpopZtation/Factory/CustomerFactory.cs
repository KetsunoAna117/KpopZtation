using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factory
{
    public class CustomerFactory
    {
        public static Customer createCustomer(String name, String email, String password, String gender, String address, String role)
        {
            return new Customer()
            {
                CustomerName = name,
                CustomerEmail = email,
                CustomerPassword = password,
                CustomerGender = gender,
                CustomerAddress = address,
                CustomerRole = role
            };
        }
    }
}