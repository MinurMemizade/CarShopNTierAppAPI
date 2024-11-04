using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Shared.Interfaces
{
    public interface IClaimService
    {
        string getUserId();
        string getClaim(string key);
    }
}
