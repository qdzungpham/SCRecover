
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmCross.Platform;
using SCRecover.Core.Interfaces;
using SCRecover.Core.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRecover.Core.Database
{
    public class SavedClaimsDatabase : ISavedClaimsDatabase
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<ClaimDetails> azureSyncTable;

        public SavedClaimsDatabase()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatabase.GetSyncTable<ClaimDetails>();
        } 

        public async Task<IEnumerable<ClaimDetails>> GetSavedClaims()
        {
            await SyncAsync(true);
            var claims = await azureSyncTable.ToListAsync();
            return claims;
        }

        public async Task<ObservableCollection<ClaimDetails>> Filter(string extra)
        {
            await SyncAsync(true);
            ObservableCollection<ClaimDetails> theCollection = new ObservableCollection<ClaimDetails>();
            theCollection = await azureSyncTable.Where(x => x.Extra == extra).OrderByDescending(x => x.Date).ToCollectionAsync();
            return theCollection;
        }
        public async Task<int> InsertClaim(ClaimDetails claim)
        {
            await SyncAsync(true);
            await azureSyncTable.InsertAsync(claim);
            await SyncAsync();
            return 1;
        }

        private async Task SyncAsync(bool pullData = false) 
        {
            try
            {
                await azureDatabase.SyncContext.PushAsync();
                
                if (pullData)
                {
                    await azureSyncTable.PullAsync("allSavedClaims", azureSyncTable.CreateQuery());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }

    
}
