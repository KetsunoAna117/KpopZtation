using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Handler;

namespace KpopZtation.Controller
{
    public class ArtistController
    {
        public static String checkArtistName(String name)
        {
            string response = "";
            if (name.Equals("")) response = "Artist name must be filled";
            response = ArtistHandler.checkUniqueArtistName(name);

            return response;
        }

        public static String checkFile(String fileExtension, int fileSize)
        {
            String[] allowedExtension = { ".png", ".jpg", ".jpeg", ".jfif" };
            const int maxSizeInBytes = 2 * 1024 * 1024; // 2 MB

            String response = "";

            if (allowedExtension.Contains(fileExtension) != true)
            {
                response = "File extension must be .png, .jpg, .jpeg, or .jfif";
            }
            else if(fileSize >= maxSizeInBytes)
            {
                response = "File size must be lower than 2MB";
            }
            return response;


        }
        public static Artist GetArtist(int id)
        {
            return ArtistHandler.GetArtist(id);
        }

        public static List<Artist> getAllArtist()
        {
            return ArtistHandler.getAllArtist();
        }

        public static void updateArtist(int id, String name, String fileName)
        {
            ArtistHandler.updateArtist(id, name, fileName);
        }



    }
}