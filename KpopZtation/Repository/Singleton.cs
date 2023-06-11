using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Repository
{
    public class Singleton
    {
        private static Database1Entities5 database;
        public static Database1Entities5 getDb()
        {
            if (database == null)
            {
                database = new Database1Entities5();
            }
            return database;
        }
    }
}