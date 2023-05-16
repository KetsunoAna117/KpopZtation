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
            else
            {
                qty = Convert.ToInt32(quantity);
                if(qty >= AlbumHandler.getAnAlbum(id).AlbumStock)
                {
                    response = "Mustn't be more than the stock album";
                }
            }
            return response;
        }
    }
}