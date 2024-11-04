using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Bussiness.DTOs.UserDTO
{
    public class ResponseDTO
    {
        public string? JwtToken { get; set; }
        public int StatusCode { get; set; }
    }
}
