using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class CartRepository
    {
        private static Database1Entities5 db = Singleton.getDb();

        public static void insertCart(int customerID, int albumID, int quantity)
        {
            db.Carts.Add(CartFactory.createCart(customerID, albumID, quantity));
            db.SaveChanges();
        }

        public static void deleteALbumCart(int customerID, int albumID)
        {
            Cart selected = (from Cart in db.Carts where (Cart.CustomerID == customerID && Cart.AlbumID == albumID) select Cart).FirstOrDefault();
            db.Carts.Remove(selected);
            db.SaveChanges();
        }

        public static List<Cart> getCart(int customerID)
        {
            return db.Carts.Where(cart => cart.CustomerID == customerID).ToList();
        }

        public static dynamic getAllCartData(int customerID)
        {
            return db.Carts.Join(
                db.Albums,
                cart => cart.AlbumID,
                album => album.AlbumID,
                (cart, album) => new
                {
                    CustomerID = cart.CustomerID,
                    AlbumID = album.AlbumID,
                    AlbumName = album.AlbumID,
                    AlbumImage = album.AlbumImage,
                    AlbumPrice = album.AlbumPrice,
                    Quantity = cart.Qty

                }).Where(c => c.CustomerID == customerID).ToList();
        }

        public static void CheckoutCart(List<Cart> carts)
        {
            db.Carts.RemoveRange(carts);
            db.SaveChanges();
        }
    }
}