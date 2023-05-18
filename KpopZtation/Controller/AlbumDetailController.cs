using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;

namespace KpopZtation.Controller
{
    public class AlbumDetailController
    {
        public static String CheckQuantity(int id, String quantity)
        {
            String response = "";
            int qty = 0;

            if (quantity.Equals("")) response = "Must be filled";
            else if(Int32.TryParse(quantity, out qty))
            {
                if (qty >= AlbumHandler.getAnAlbum(id).AlbumStock)
                {
                    response = "Mustn't be more than the stock album";
                }
            }
            else
            {
                response = "Input must be integer";
            }
            return response;
        }

        public static void addToCart(int customerID, int AlbumId, int quantity)
        {
            CartHandler.AddItemsToCart(customerID, AlbumId, quantity);
            HttpContext.Current.Response.Redirect("~/Views/Cart.aspx");
        }
    }
}