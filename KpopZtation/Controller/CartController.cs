using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Handler;

namespace KpopZtation.Controller
{
    public class CartController
    {
        public static dynamic GetShowedCartDatas(int customerID)
        {
            return CartHandler.getCartData(customerID);
        }

        public static void deleteCart(int customerID, int albumID)
        {
            CartHandler.deleteItemFromCart(customerID, albumID);
        }

        public static void CheckOut(int customerID)
        {
            CartHandler.DeleteCart(customerID);
            HttpContext.Current.Response.Redirect("~/Views/Home.aspx");
        }
    }
}