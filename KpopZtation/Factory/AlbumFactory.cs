using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class AlbumFactory
    {
        public static Album createAlbum(int artistId, String albumName, String albumImage, int albumPrice, int albumStock, String albumDescription)
        {
            return new Album()
            {
                ArtistID = artistId,
                AlbumName = albumName,
                AlbumImage = albumImage,
                AlbumPrice = albumPrice,
                AlbumDescription = albumDescription,
                AlbumStock = albumStock
            };
        }
        
    }
}