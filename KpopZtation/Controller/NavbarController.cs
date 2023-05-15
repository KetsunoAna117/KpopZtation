using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;
using KpopZtation.Repository;
using KpopZtation.Model;

namespace KpopZtation.Controller
{
    public class NavbarController
    {

        public static void HandleUserState()
        {
            CustomerHandler.loadCookie();

            if (IsUserLoggedIn())
            {
                // User is logged in
                HttpContext.Current.Session["IsUserLoggedIn"] = true;
            }
            else
            {
                // User is not logged in
                HttpContext.Current.Session["IsUserLoggedIn"] = false;
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

        public static void doSignOut()
        {
            CustomerHandler.ProcessLogOut();

            // Redirect to the login page
            HttpContext.Current.Response.Redirect("~/Views/SignIn/Login.aspx");
        }
    }
}