using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Bussiness.DTOs.Commons
{
    public interface IAuditedEntity
    {
        public IFormFile Image { get; set; }
    }
}
