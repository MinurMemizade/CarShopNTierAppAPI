using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierApp.Bussiness.DTOs.UserDTO;
using NTierApp.Bussiness.Services.Interfaces;

namespace NTierApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] LoginDTO loginDTO)
        {
            return Ok(await accountService.LoginAsync(loginDTO));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsycn([FromForm] RegisterDTO register)
        {
            await accountService.RegisterAsync(register);
            return Ok();
        }
    }
}
