﻿using System;
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
            if (getArtistByName(name) != null) response = "Artist name has been inserted (must unique)";

            return response;
        }

        public static void insertArtist(String name, String imageName)
        {
            ArtistRepository.addArtist(name, imageName);
        }

        public static void updateArtist(int id, string name, string imageName)
        {
            ArtistRepository.updateArtist(id, name, imageName);
        }

        public static void deleteArtist(int id)
        {
            ArtistRepository.deleteArtist(id);
        }

        public static Artist getArtistByName(string name)
        {
            return ArtistRepository.GetArtistByName(name);
        }

        public static Artist GetArtist(int id)
        {
            return ArtistRepository.getArtist(id);
        }

        public static List<Artist> getAllArtist()
        {
            return ArtistRepository.getAllArtist();
        }

    }
}