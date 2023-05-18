using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Repository;

namespace KpopZtation.Handler
{
    public class CartHandler
    {
        public class ShowedCartData
        {
            public string AlbumName { get; set; }
            public string AlbumImage { get; set; }
            public int AlbumPrice { get; set; }
            public int Quantity { get; set; }
        }
        public static void AddItemsToCart(int customerID, int albumID, int quantity)
        {
            CartRepository.insertCart(customerID, albumID, quantity);
        }

        public static List<ShowedCartData> getCartData(int customerId)
        {
            List<Cart> carts = CartRepository.getAllCartData().Where(cart => cart.CustomerID == customerId).ToList();
            List<Album> albums = AlbumRepository.getAllAlbum();

            List<ShowedCartData> toShow = new List<ShowedCartData>();
            foreach (Cart c in carts)
            {
                Album album = albums.FirstOrDefault(a => a.AlbumID == c.AlbumID);
                if(album != null)
                {
                    ShowedCartData item = new ShowedCartData
                    {
                        AlbumImage = album.AlbumImage,
                        AlbumPrice = album.AlbumPrice,
                        AlbumName = album.AlbumName,
                        Quantity = c.Qty
                    };

                    toShow.Add(item);
                }
            }

            return toShow;            
        }

        public static void DeleteCart(int customerID)
        {
            List<Cart> carts = CartRepository.getAllCartData().Where(c => c.CustomerID == customerID).ToList();
            // push to transaction header
            int thID = TransactionHeaderRepository.insertTransactionHeader(DateTime.Now, customerID);

            // push to transactionDetail
            foreach(Cart cart in carts)
            {
                TransactionDetailRepository.insertTransactionDetail(thID, cart.AlbumID, cart.Qty);
            }


            // substract stock
            AlbumRepository.UpdateAlbumStock(carts);
       

            // Checkout
            CartRepository.CheckoutCart(carts);
        }
    }
}