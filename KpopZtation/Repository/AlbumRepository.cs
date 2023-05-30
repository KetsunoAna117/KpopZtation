using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class AlbumRepository
    {
        private static Database1Entities2 db = Singleton.getDb();

        public static void addAlbum(String albumName, int ArtistID, String albumImage, int albumPrice, int albumStock, String albumDescription)
        {
            db.Albums.Add(AlbumFactory.createAlbum(albumName, ArtistID, albumImage, albumPrice, albumStock, albumDescription));
            db.SaveChanges();
        }

        public static void deleteAlbum(int albumID)
        {
            Album selectedAlbum = db.Albums.Find(albumID);
            db.Albums.Remove(selectedAlbum);
            db.SaveChanges();
        }

        public static void updateAlbum(int albumID, int artistId, String albumName, String albumImage, int albumPrice, int albumStock, String albumDescription)
        {
            Album selectedAlbum = db.Albums.Find(albumID);
            selectedAlbum.ArtistID = artistId;
            selectedAlbum.AlbumName = albumName;
            selectedAlbum.AlbumImage = albumImage;
            selectedAlbum.AlbumPrice = albumPrice;
            selectedAlbum.AlbumStock = albumStock;
            selectedAlbum.AlbumDescription = albumDescription;

            db.SaveChanges();
        }

        public static void UpdateAlbumStock(List<Cart> albumToUpdate)
        {
            foreach (Cart cart in albumToUpdate)
            {
                Album selectedAlbum = db.Albums.Find(cart.AlbumID);
                if (selectedAlbum != null)
                {
                    selectedAlbum.AlbumStock = selectedAlbum.AlbumStock - cart.Qty;
                }
            }
            db.SaveChanges();
        }

        public static Album getAlbum(int albumID)
        {
            return db.Albums.Find(albumID);
        }

        public static List<Album> getAllAlbum()
        {
            return db.Albums.ToList();
        }
        public static List<Album> getAlbumByArtist(int ArtistID)
        {
            return (from albums in db.Albums where (albums.ArtistID == ArtistID) select albums).ToList();
        }
    }
}