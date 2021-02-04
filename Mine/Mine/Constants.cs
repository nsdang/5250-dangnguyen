using System;
using System.IO;

namespace Mine
{
    public static class Constants
    {
        //public const string DatabaseFilename = "TodoSQLite.db3";
        public const string DatabaseFilename = "mine1.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // Open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Create the database if it desn't exist
            SQLite.SQLiteOpenFlags.Create |
            // Enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
        
    }
}
