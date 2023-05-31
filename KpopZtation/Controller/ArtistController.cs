using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Handler;
using System.Web.UI.WebControls;
using System.IO;

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

        public static String ValidateFile(String fileExtension, int fileSize)
        {
            String[] allowedExtension = { ".png", ".jpg", ".jpeg", ".jfif" };
            const int maxSizeInBytes = 2 * 1024 * 1024; // 2 MB

            String response = "";

            if (allowedExtension.Contains(fileExtension) != true)
            {
                response = "File extension must be .png, .jpg, .jpeg, or .jfif";
            }
            else if (fileSize >= maxSizeInBytes)
            {
                response = "File size must be lower than 2MB";
            }
            return response;

        }

        public static String CheckFile(FileUpload ArtistImageFile)
        {
            String response;
            if (ArtistImageFile.HasFile)
            {
                String fileExtension = Path.GetExtension(ArtistImageFile.FileName).ToLower();
                int fileSize = ArtistImageFile.FileBytes.Length;

                response = ValidateFile(fileExtension, fileSize);

            }
            else
            {
                response = "Must be chosen";
            }

            return response;
        }

        public static void UpdateArtist(Artist artist, String artistName, FileUpload ArtistImageFile)
        {
            String filePath = HttpContext.Current.Server.MapPath("~/Assets/ArtistImage/") + artist.ArtistImage;
            HomeController.DeleteFile(filePath);

            String fileName = ArtistImageFile.FileName;
            filePath = HttpContext.Current.Server.MapPath("~/Assets/ArtistImage/") + fileName;

            ArtistImageFile.SaveAs(filePath);

            ArtistHandler.updateArtist(artist.ArtistID, artistName, fileName);
            HttpContext.Current.Response.Redirect("~/Views/Home.aspx");
        }

        public static void InsertArtist(String artistName, FileUpload ArtistImageFile)
        {
            string fileName = ArtistImageFile.FileName;
            string filePath = HttpContext.Current.Server.MapPath("~/Assets/ArtistImage/") + fileName;

            ArtistImageFile.SaveAs(filePath);

            ArtistHandler.insertArtist(artistName, fileName);
            HttpContext.Current.Response.Redirect("~/Views/Home.aspx");
        }

        public static Artist GetArtist(int id)
        {
            return ArtistHandler.GetArtist(id);
        }

        public static List<Artist> getAllArtist()
        {
            return ArtistHandler.getAllArtist();
        }


    }
}