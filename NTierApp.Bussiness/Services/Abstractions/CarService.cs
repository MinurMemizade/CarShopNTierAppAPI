using NTierApp.Bussiness.DTOs.CarDTO;
using NTierApp.Bussiness.Services.Interfaces;
using NTierApp.Core.Entities;
using NTierApp.Dal.Repositories.Abstractions;
using NTierApp.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Bussiness.Services.Abstractions
{
    public class CarService:ICarService
    {
        private readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public  void CreateAsync(CarDTO carDTO)
        {
            Car car = new Car()
            {
                Make = carDTO.Make,
                Model = carDTO.Model,
                Mileage = carDTO.Mileage,
                Description = carDTO.Description,
                Engine = carDTO.Engine,
                HorsePower = carDTO.HorsePower,
                IsNew = carDTO.IsNew,
                Price = carDTO.Price,
                Year = carDTO.Year,
            };
             carRepository.CreateAsync(car);
        }

        public  void DeleteAsync(int Id)
        {
             carRepository.DeleteByIdAsync(Id);
        }

        public  Task<List<Car>> GetAllAsync()
        {
            return  carRepository.GetAllAsync();
        }

        public async Task<Car> GetByIdAsync(int Id)
        {
            return await carRepository.GetByIdAsync(Id);
        }

        public  void UpdateAsync(UpdateCarDTO updatecarDTO)
        {
            Car updatedCar = new Car()
            {
                Id = updatecarDTO.Id,
                Make = updatecarDTO.Make,
                Model = updatecarDTO.Model,
                Mileage = updatecarDTO.Mileage,
                Description = updatecarDTO.Description,
                Engine = updatecarDTO.Engine,
                HorsePower = updatecarDTO.HorsePower,
                IsNew = updatecarDTO.IsNew,
                Price = updatecarDTO.Price,
                Year = updatecarDTO.Year,
            };
             carRepository.UpdateByIdAsync(updatedCar);
        }
    }
}
