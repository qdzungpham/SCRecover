using SCRecover.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SCRecover.Core.Interfaces
{
    public interface ISavedClaimsDatabase
    {
        Task<ObservableCollection<ClaimDetails>> Filter(string type);
        Task<int> InsertClaim(ClaimDetails newClaim);
        Task<int> DeleteClaim(object id);

        Task<ClaimDetails> GetProfile();
        Task<int> UpdateProfile(ClaimDetails newProfile, ClaimDetails oldProfile);
    }
    
}
