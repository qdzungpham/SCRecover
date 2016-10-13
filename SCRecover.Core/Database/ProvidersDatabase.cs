using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmCross.Platform;
using SCRecover.Core.Interfaces;
using SCRecover.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRecover.Core.Database
{
    public class ProvidersDatabase : IProvidersDatabase
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<ProviderDetails> azureSyncTable;

        public ProvidersDatabase()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatabase.GetSyncTable<ProviderDetails>();
        }

        public async Task<bool> CheckIfExists(ProviderDetails provider)
        {
            await SyncAsync(true);
            var providers = await azureSyncTable.Where(x => x.Name == provider.Name || x.Address == provider.Address).ToListAsync();
            return providers.Any();
        }

        public async Task<ObservableCollection<ProviderDetails>> GetAll()
        {
            await SyncAsync(true);
            ObservableCollection<ProviderDetails> theCollection = new ObservableCollection<ProviderDetails>();
            theCollection = await azureSyncTable.ToCollectionAsync();
            return theCollection;
        }

        public async Task<int> InsertProvider(ObservableCollection<ProviderDetails> entities)
        {
            await SyncAsync(true);
            if (entities != null && entities.Count > 0)
            {
                try
                {
                    azureDatabase.GetTable<ProviderDetails>();

                    foreach (ProviderDetails one in entities)
                    {
                        await azureSyncTable.InsertAsync(one);
                    }
                }
                catch (Exception ex)
                {
                    ReportError(ex);
                }
            }
            await SyncAsync();
            return 1;
        }

        private void ReportError(Exception ex)
        {
            throw new NotImplementedException();
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
