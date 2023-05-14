using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;

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

        public static String DoLogin(String email, String password)
        {
            String response = CustomerHandler.validateLogin(email, password);
            return response;
            
        }
    }
}