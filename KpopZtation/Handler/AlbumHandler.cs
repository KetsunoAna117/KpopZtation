using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repository;
using KpopZtation.Model;

namespace KpopZtation.Handler
{
    public class AlbumHandler
    {
        public static void InsertAlbum(String name, int ArtistID, String description, int price, int stock, string imageName)
        {
            AlbumRepository.addAlbum(name, ArtistID, imageName, price, stock, description);
        }

        public static void UpdateAlbum(int albumID, int artistId, String albumName, String albumImage, int albumPrice, int albumStock, String albumDescription)
        {
            AlbumRepository.updateAlbum(albumID, artistId, albumName, albumImage, albumPrice, albumStock, albumDescription);
        }

        public static void DeleteAlbum(int albumID)
        {
            AlbumRepository.deleteAlbum(albumID);
        }

        public static List<Album> getAlbums(int artistID)
        {
            return AlbumRepository.getAlbumByArtist(artistID);
        }

        public static Album getAnAlbum(int id)
        {
            return AlbumRepository.getAlbum(id);
        }

    }
}