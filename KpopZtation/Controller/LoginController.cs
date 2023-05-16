using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;
using KpopZtation.Model;

namespace KpopZtation.Controller
{
    public class LoginController
    {
        public static String CheckEmail(String email)
        {
            String response = "";
            if (email.Equals("")) response = "Email cannot be empty";

            return response;
        }

        public static String CheckPassword(String password)
        {
            String response = "";
            if (password.Equals("")) response = "Password cannot be empty";

            return response;
        }

        public static String CheckLogin(String email, String password)
        {
            String response = CustomerController.ValidateLogin(email, password);
            return response;
            
        }

        public static void doLogin(string email, string password, bool rememberMe)
        {
            if(CustomerController.AuthenticateUser(email, password))
            {
                CustomerController.ProcessLoginSuccess(email, password, rememberMe);
            }
            else
            {
                CustomerController.ProcessLoginFailed();
            }
        }

    }
}