using Microsoft.AspNetCore.Http;
using NTierApp.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Shared.Abstractions
{
    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string getClaim(string key)
        {
            var result = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value
                ?? httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault()?.Value;
            return result;
        }

        public string getUserId()
        {
            return getClaim(ClaimTypes.Name);
        }
    }
}
