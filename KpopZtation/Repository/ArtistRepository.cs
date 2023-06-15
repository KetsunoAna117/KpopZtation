using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class ArtistRepository
    {
        private static Database1Entities6 db = Singleton.getDb();

        public static void addArtist(String name, String image)
        {
            db.Artists.Add(ArtistFactory.createArtist(name, image));
            db.SaveChanges();
        }

        public static void deleteArtist(int id)
        {
            Artist selectedArtist = db.Artists.Find(id);
            db.Artists.Remove(selectedArtist);

            db.SaveChanges();

        }

        public static void updateArtist(int id, String name, String image)
        {
            Artist selectedArtist = db.Artists.Find(id);
            selectedArtist.ArtistName = name;
            selectedArtist.ArtistImage = image;

            db.SaveChanges();
        }

        public static Artist getArtist(int id)
        {
            return db.Artists.Find(id);
        }

        public static Artist GetArtistByName(String name)
        {
            return (from artist in db.Artists where (artist.ArtistName) == name select artist).FirstOrDefault();
        }

        public static List<Artist> getAllArtist()
        {
            return db.Artists.ToList();
        }
    }
}