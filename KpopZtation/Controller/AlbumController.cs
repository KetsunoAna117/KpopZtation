using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using KpopZtation.Handler;
using KpopZtation.Model;

namespace KpopZtation.Controller
{
    public class AlbumController
    {
        public static String CheckName(String name)
        {
            String response = "";
            if (name.Equals("")) response = "Must be filled";
            else if (name.Length >= 50) response = "Must be smaller than 50 character(s)";
            return response;
        }

        public static String CheckDescription(String desc)
        {
            String response = "";
            if (desc.Equals("")) response = "Must be filled";
            else if (desc.Length >= 255) response = "Must be smaller than 255 character(s)";
            return response;
        }

        public static String CheckPrice(String price)
        {
            String response = "";
            int priceInt = 0;

            if (price.Equals(""))
            {
                response = "Must be filled";
            }
            else if (Int32.TryParse(price, out priceInt))
            {
                if (priceInt < 100000 || priceInt > 1000000) response = "Must between 100000 and 1000000";
            }
            else
            {
                response = "Must be in Integer";
            }

            return response;
        }

        public static String CheckStock(String stock)
        {
            String response = "";
            int stockInt = 0;

            if (stock.Equals(""))
            {
                response = "Must be filled";
            }
            else if (Int32.TryParse(stock, out stockInt))
            {
                if (stockInt <= 0) response = "Must be more than 0";
            }
            else
            {
                response = "Must be in Integer";
            }

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

        public static String CheckFile(FileUpload AlbumImageFile)
        {
            String response;
            if (AlbumImageFile.HasFile)
            {
                String fileExtension = Path.GetExtension(AlbumImageFile.FileName).ToLower();
                int fileSize = AlbumImageFile.FileBytes.Length;

                response = ValidateFile(fileExtension, fileSize);

            }
            else
            {
                response = "Must be chosen";
            }

            return response;
        }

        public static List<Album> getAlbums(int artistID)
        {
            return AlbumHandler.getAlbums(artistID);
        }

        public static Album getAnAlbum(int albumID)
        {
            return AlbumHandler.getAnAlbum(albumID);
        }

        public static void insertAlbum(String name, int ArtistID, String description, int price, int stock, FileUpload albumImage)
        {
            string fileName = albumImage.FileName;
            string filePath = HttpContext.Current.Server.MapPath("~/Assets/AlbumImage/") + fileName;

            albumImage.SaveAs(filePath);

            AlbumHandler.InsertAlbum(name, ArtistID, description, price, stock, fileName);
            HttpContext.Current.Response.Redirect("~/Views/ArtistPage/ArtistDetail.aspx?id=" + ArtistID);

        }

        public static void UpdateAlbum(int albumID, int artistId, String albumName, FileUpload albumImage, int albumPrice, int albumStock, String albumDescription)
        {
            string fileName = albumImage.FileName;
            string filePath = HttpContext.Current.Server.MapPath("~/Assets/AlbumImage/") + fileName;

            albumImage.SaveAs(filePath);

            AlbumHandler.UpdateAlbum(albumID, artistId, albumName, fileName, albumPrice, albumStock, albumDescription);
            HttpContext.Current.Response.Redirect("~/Views/ArtistPage/ArtistDetail.aspx?id=" + artistId);


        }
    }
}