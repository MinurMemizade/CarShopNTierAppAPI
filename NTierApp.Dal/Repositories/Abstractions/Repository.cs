using Microsoft.EntityFrameworkCore;
using NTierApp.Core.Common;
using NTierApp.Dal.Context;
using NTierApp.Dal.Repositories.Interfaces;

namespace NTierApp.Bussiness.Abstractions
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()

    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _table;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _table = appDbContext.Set<T>();
        }
        public async void CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public  void DeleteByIdAsync(int id)
        {
            T entity =  _table.Find(id); //asinxron yazanda Thread error verir
            if (entity != null)
            {
                _table.Remove(entity);
                 _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = await _table.FindAsync(id);
            return entity;
        }

        public void UpdateByIdAsync(T entity)
        {
            _table.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
