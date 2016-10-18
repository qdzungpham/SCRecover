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
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using SCRecover.Core.Models;

namespace SCRecover.Droid.Database
{
    public class AzureDatabase : IAzureDatabase
    {
        MobileServiceClient azureDatabase;
        public MobileServiceClient GetMobileServiceClient()
        {
            CurrentPlatform.Init();
            azureDatabase = new MobileServiceClient("http://suncorphealth.azurewebsites.net");
            InitializeLocal();
            return azureDatabase;

        }

        private void InitializeLocal()
        {
            var sqliteFilename = "SCRecoverySQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<ClaimDetails>();
            azureDatabase.SyncContext.InitializeAsync(store);
        }
    }
}