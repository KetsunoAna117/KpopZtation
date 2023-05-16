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
    public class ArtistDetailController
    {
        public static void DeleteFile(String filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void SelectAlbum(int id)
        {
            Album Album = AlbumHandler.getAnAlbum(id);
            if (Album != null)
            {
                HttpContext.Current.Response.Redirect("~/Views/AlbumPage/AlbumDetail.aspx?id=" + Album.AlbumID);
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Views/Home.aspx");

            }

        }

        public static void UpdateAlbum(int id)
        {
            Album Album = AlbumHandler.getAnAlbum(id);
            if (Album != null)
            {
                HttpContext.Current.Response.Redirect("~/Views/AlbumPage/UpdateAlbum.aspx?id=" + Album.AlbumID);
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Views/Home.aspx");

            }
        }

        public static void deleteAlbum(int id, String filePath)
        {
            Album album = AlbumHandler.getAnAlbum(id);
            String imagePath = filePath + album.AlbumImage;

            DeleteFile(imagePath);

            AlbumHandler.DeleteAlbum(album.AlbumID);
            HttpContext.Current.Response.Redirect("~/Views/Home.aspx");
        }
    }
}