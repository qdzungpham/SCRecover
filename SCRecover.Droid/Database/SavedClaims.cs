using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SCRecover.Core.Interfaces;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;

namespace SCRecover.Droid.Database
{
    public class SavedClaims : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SavedClaims.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            return conn;
        }
    }
}