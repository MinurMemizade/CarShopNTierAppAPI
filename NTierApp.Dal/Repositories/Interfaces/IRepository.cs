using NTierApp.Core;
using NTierApp.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Dal.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void DeleteByIdAsync(int id);
        void UpdateByIdAsync(T entity);
        void CreateAsync(T entity);
    }
}
