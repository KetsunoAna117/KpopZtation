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

        public static void AddItemsToCart(int customerID, int albumID, int quantity)
        {
            CartRepository.insertCart(customerID, albumID, quantity);
        }

        public static dynamic getCartData(int customerId)
        {
            return CartRepository.getAllCartData(customerId);
        }

        public static void DeleteCart(int customerID)
        {
            var carts = CartRepository.getAllCartData(customerID);
            // push to transaction header
            int thID = TransactionHeaderRepository.insertTransactionHeader(DateTime.Now, customerID);

            // push to transactionDetail
            foreach (Cart cart in carts)
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