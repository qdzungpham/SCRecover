
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


        public async Task<ObservableCollection<ClaimDetails>> Filter(string extra)
        {
            await SyncAsync(true);
            ObservableCollection<ClaimDetails> theCollection = new ObservableCollection<ClaimDetails>();
            theCollection = await azureSyncTable.Where(x => x.Extra == extra).OrderByDescending(x => x.Date).ToCollectionAsync();
            return theCollection;
        }

        public async Task<int> UpdateProfile(ClaimDetails newProfile, ClaimDetails oldProfile)
        {
            await SyncAsync(true);
            var profile = await azureSyncTable.Where(x => x.Extra == "profile").ToListAsync();
            if (profile.Any())
            {
                await azureSyncTable.UpdateAsync(oldProfile);
                await SyncAsync();
            }
            else
            {
                await azureSyncTable.InsertAsync(newProfile);
                await SyncAsync();
            }
        
            return 1;
        } 
        
        public async Task<ClaimDetails> GetProfile()
        {
            await SyncAsync(true);
            ClaimDetails myProfile = new ClaimDetails();
            var profile = await azureSyncTable.Where(x => x.Extra == "profile").ToListAsync();
            if (profile.Any())
            {
                myProfile = profile.FirstOrDefault();
            }
            return myProfile;
        }
        public async Task<int> InsertClaim(ClaimDetails claim)
        {
            await SyncAsync(true);
            await azureSyncTable.InsertAsync(claim);
            await SyncAsync();
            return 1;
        }

        public async Task<int> DeleteClaim(object id)
        {
            await SyncAsync(true);
            var claim = await azureSyncTable.Where(x => x.Id == (string)id).ToListAsync();
            if (claim.Any())
            {
                await azureSyncTable.DeleteAsync(claim.FirstOrDefault());
                await SyncAsync();
                return 1;
            }
            else
            {
                return 0;

            }
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
