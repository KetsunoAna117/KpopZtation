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

        public static bool AuthenticateUser(string email, string password)
        {
            Customer userData = CustomerRepository.getCustomer(email, password);
            if (userData != null)
            {
                return true;
            }
            return false;
        }

        public static void loadCookie()
        {
            if (HttpContext.Current.Request.Cookies["User_Cookie"] != null)
            {
                Customer userData = CustomerRepository.getCustomerByID(Convert.ToInt32(HttpContext.Current.Request.Cookies["User_Cookie"].Value));

                HttpContext.Current.Session["User"] = userData;
            }
        }

        public static void ProcessLoginSuccess(string email, string password, bool rememberMe)
        {

            Customer userData = CustomerRepository.getCustomer(email, password);

            if (rememberMe)
            {
                // Create a cookie to remember the user
                HttpCookie cookie = new HttpCookie("User_Cookie");
                cookie.Value = userData.CustomerID.ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            HttpContext.Current.Session["User"] = userData;
            HttpContext.Current.Response.Redirect("~/Views/Home.aspx");
            
        }

        public static void ProcessLoginFailed()
        {
            HttpContext.Current.Session["User"] = null;
            HttpContext.Current.Session["IsUserLoggedIn"] = false;
            HttpContext.Current.Response.Redirect("~/Views/Login.aspx?error=invalid");
        }

        public static void ProcessLogOut()
        {
            // Clear the session
            HttpContext.Current.Session.Remove("User");

            // Clear all cookies
            string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {
                HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }

        public static bool IsUserLoggedIn()
        {
            return HttpContext.Current.Session["User"] != null;
        }


        public static Customer GetLoggedInUser()
        {
            return (Customer)HttpContext.Current.Session["User"];
        }

        //public static bool isAdmin()
        //{
        //    Customer loggedInUser = GetLoggedInUser();
        //    return loggedInUser != null && loggedInUser.CustomerRole.ToString() == "ADMIN";
        //}

        public static bool isAdmin()
        {
            if (HttpContext.Current.Request.Cookies["User_Cookie"] != null)
            {
                Customer userData = CustomerRepository.getCustomerByID(Convert.ToInt32(HttpContext.Current.Request.Cookies["User_Cookie"].Value));
                return userData != null && userData.CustomerRole.ToString() == "ADMIN";
            }

            return false;
        }


    }
}