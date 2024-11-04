using App.Business.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NTierApp.Bussiness.DTOs.UserDTO;
using NTierApp.Bussiness.Services.Interfaces;
using NTierApp.Core.Entities.Identity;
using NTierApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Bussiness.Services.Abstractions
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        public async Task<ResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            var oldUser=await userManager.FindByEmailAsync(loginDTO.UsernameOrEmail) 
                ?? await userManager.FindByNameAsync(loginDTO.UsernameOrEmail);

            if (oldUser == null) 
            {
                throw new Exception("Username/Email or Password is not valid.");
            }

            if (!await userManager.CheckPasswordAsync(oldUser, loginDTO.Password)) 
            {
                throw new Exception("Username/Email or Password is not valid.");
            }

            var userRole=await GetUserRole(oldUser);
            var jwtToken = JwtGenerator.GenerateToken(oldUser, EUserRole.Admin, configuration);

           return new ResponseDTO
            {
                JwtToken = jwtToken,
                StatusCode = 200,
            };
        }



        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            var newUser = new User()
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
            };
            await AddRolesToDatabaseAsync();

            IdentityResultChecker(await userManager.CreateAsync(newUser,registerDTO.Password));
            IdentityResultChecker(await userManager.AddToRoleAsync(newUser,EUserRole.Admin.ToString()));
        }



        public void IdentityResultChecker(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.FirstOrDefault().Description);  
            }
        }



        public async Task<string> GetUserRole(User user)
        { 
            return (await userManager.GetRolesAsync(user)).FirstOrDefault();
        }



        public async Task AddRolesToDatabaseAsync()
        {
            foreach(var item in Enum.GetValues(typeof(EUserRole)))
            {
                if(await roleManager.RoleExistsAsync(item.ToString()))
                {
                    await roleManager.CreateAsync(new IdentityRole(item.ToString()));
                }
            }
        }
    }
}