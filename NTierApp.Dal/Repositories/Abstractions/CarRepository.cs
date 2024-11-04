using NTierApp.Bussiness.Abstractions;
using NTierApp.Core.Entities;
using NTierApp.Dal.Context;
using NTierApp.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Dal.Repositories.Abstractions
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
