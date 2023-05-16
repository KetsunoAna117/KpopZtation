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
    public class HomeController
    {

        public static void DeleteFile(String filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void deleteArtist(int id, String filePath)
        {
            Artist artist = ArtistHandler.GetArtist(id);
            String imagePath = filePath + artist.ArtistImage;

            DeleteFile(imagePath);

            ArtistHandler.deleteArtist(artist.ArtistID);
            HttpContext.Current.Response.Redirect("~/Views/Home.aspx");
        }

        public static void UpdateArtist(int id)
        {
            Artist artist = ArtistHandler.GetArtist(id);
            if(artist != null)
            {
                HttpContext.Current.Response.Redirect("~/Views/ArtistPage/UpdateArtist.aspx?id=" + artist.ArtistID);

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Views/Home.aspx");

            }
        }

        //public static void SelectArtist(GridViewRow row)
        //{
        //    Artist artist = ArtistHandler.getArtistByName(row.Cells[1].Text);
        //    HttpContext.Current.Response.Redirect("~/Views/ArtistPage/ArtistDetail.aspx?id=" + artist.ArtistID);
        //}

        public static void SelectArtist(int id)
        {
            Artist artist = ArtistHandler.GetArtist(id);
            if(artist != null)
            {
                HttpContext.Current.Response.Redirect("~/Views/ArtistPage/ArtistDetail.aspx?id=" + artist.ArtistID);    
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Views/Home.aspx");

            }

        }


    }
}