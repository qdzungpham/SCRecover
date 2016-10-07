using SCRecover.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRecover.Core.Interfaces
{
    public interface ISavedClaimsDatabase
    {
        Task<IEnumerable<ClaimDetails>> GetClaimDetails();
        //void SaveClaim(ClaimDetails claim);
        Task<int> SaveClaim(ClaimDetails location);
    }
    
}
