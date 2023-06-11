using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factory
{
    public class AlbumFactory
    {
        public static Album createAlbum(String albumName, int artistID, String albumImage, int albumPrice, int albumStock, String albumDescription)
        {
            return new Album()
            {
                AlbumName = albumName,
                ArtistID = artistID,
                AlbumImage = albumImage,
                AlbumPrice = albumPrice,
                AlbumDescription = albumDescription,
                AlbumStock = albumStock
            };
        }
        
    }
}