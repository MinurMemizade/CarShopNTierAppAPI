using NTierApp.Bussiness.DTOs.CarDTO;
using NTierApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Bussiness.Services.Interfaces
{
    public interface ICarService
    {
        public void  CreateAsync(CarDTO carDTO);
        public void UpdateAsync(UpdateCarDTO updateCarDTO);
        public void DeleteAsync(int Id);
        public Task<Car> GetByIdAsync(int Id);
        public Task<List<Car>> GetAllAsync();
    }
}
