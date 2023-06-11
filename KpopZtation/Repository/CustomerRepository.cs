using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factory;
using System.Data.Entity.Validation;

namespace KpopZtation.Repository
{
    public class CustomerRepository
    {
        private static Database1Entities5 db = Singleton.getDb();

        public static void insertCustomer(string name, string email, string password, string gender, string address, string role)
        {
            db.Customers.Add(CustomerFactory.createCustomer(name, email, password, gender, address, role));
            db.SaveChanges();
        }

        public static void updateCustomer(int id, String name, String email, String password, String gender, String address, String role)
        {
            Customer selectedCustomer = db.Customers.Find(id);
            selectedCustomer.CustomerName = name;
            selectedCustomer.CustomerEmail = email;
            selectedCustomer.CustomerPassword = password;
            selectedCustomer.CustomerGender = gender;
            selectedCustomer.CustomerAddress = address;
            selectedCustomer.CustomerRole = role;

            db.SaveChanges();
        }

        public static void deleteCustomer(int id)
        {
            Customer selectedCustomer = db.Customers.Find(id);
            db.Customers.Remove(selectedCustomer);
            db.SaveChanges();
        }

        public static Customer findCustomerByEmail(String email)
        {
            return (from customer in db.Customers where customer.CustomerEmail == email select customer).FirstOrDefault();
        }

        public static Customer getCustomerByID(int id)
        {
            return db.Customers.Find(id);
        }

        public static Customer GetCustomer(int id)
        {
            return db.Customers.Find(id);
        }

        public static List<Customer> getAllCustomer()
        {
            return db.Customers.ToList();
        }

        public static Customer GetCustomer(String email, String password)
        {
            return (from customer in db.Customers where customer.CustomerEmail == email && customer.CustomerPassword == password select customer).FirstOrDefault();
        }
    }
}