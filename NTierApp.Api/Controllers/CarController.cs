using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierApp.Bussiness.DTOs.CarDTO;
using NTierApp.Bussiness.Services.Abstractions;
using NTierApp.Bussiness.Services.Interfaces;
using NTierApp.Core.Enums;

namespace NTierApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet("GetAll")]
        
        public async Task<IActionResult> GetAllCars()
        {
            var result = await carService.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetById")]
      
        public async Task<IActionResult> GetCarById(int id)
        {
            var result = await carService.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("Create")]
       
        public async Task<IActionResult> CreateCarAsync([FromForm] CarDTO carDTO)
        {
            carService.CreateAsync(carDTO);
            return StatusCode(StatusCodes.Status201Created, carDTO);
        }

        [HttpPut("Update")]
        
        public async Task<IActionResult> UpdateCarAsync([FromForm] UpdateCarDTO updateCarDTO)
        {
            carService.UpdateAsync(updateCarDTO);
            return StatusCode(StatusCodes.Status202Accepted, updateCarDTO);
        }

        [HttpDelete("Delete")]
        
        public async Task<IActionResult> DeleteCarAsync(int id)
        {
            carService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status202Accepted, null);
        }
    }
}
