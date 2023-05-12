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

        public static void addAlbum(int artistId, String albumName, String albumImage, int albumPrice, int albumStock, String albumDescription)
        {
            db.Albums.Add(AlbumFactory.createAlbum(artistId, albumName, albumImage, albumPrice, albumStock, albumDescription));
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
            selectedAlbum.AlbumPrice = albumStock;
            selectedAlbum.AlbumDescription = albumDescription;

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
    }
}