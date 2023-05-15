using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repository;
using KpopZtation.Model;

namespace KpopZtation.Handler
{
    public class ArtistHandler
    {
        public static String checkUniqueArtistName(String name)
        {
            String response = "";
            if (ArtistRepository.GetArtistByName(name) != null) response = "Artist name has been inserted (must unique)";

            return response;
        }

        public static void insertArtist(String name, String imageName)
        {
            ArtistRepository.addArtist(name, imageName);
        }

        public static List<Artist> getAllArtist()
        {
            return ArtistRepository.getAllArtist();
        }

    }
}