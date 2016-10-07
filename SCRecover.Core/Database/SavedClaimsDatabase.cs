using MvvmCross.Platform;
using SCRecover.Core.Interfaces;
using SCRecover.Core.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRecover.Core.Database
{
    public class SavedClaimsDatabase : ISavedClaimsDatabase
    {
        private SQLiteConnection database;
        public SavedClaimsDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<ClaimDetails>();
        }

        public async Task<IEnumerable<ClaimDetails>> GetClaimDetails()
        {
            return database.Table<ClaimDetails>().ToList();
        }
        public async Task<int> SaveClaim(ClaimDetails claim)
        {
            var num = database.Insert(claim);
            database.Commit();
            return num;
        }
    }
}
