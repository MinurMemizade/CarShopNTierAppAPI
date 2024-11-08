﻿using NTierApp.Bussiness.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Bussiness.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterDTO registerDTO);
        Task <ResponseDTO> LoginAsync(LoginDTO loginDTO);
    }
}
