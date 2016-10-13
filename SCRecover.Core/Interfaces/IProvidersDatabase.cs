using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SCRecover.Core.Models;
using System.Collections.Generic;

namespace SCRecover.Core.Interfaces
{
    public interface IProvidersDatabase
    {
        Task<ObservableCollection<ProviderDetails>> GetAll();
        Task<int> InsertProvider(ObservableCollection<ProviderDetails> provider);
        Task<bool> CheckIfExists(ProviderDetails provider);
    }
}