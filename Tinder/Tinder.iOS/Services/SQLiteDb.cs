using Tinder.Services;
using SQLite;
using System;
using System.IO;

namespace Tinder.iOS.Services
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(dbPath, "Tinder.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}