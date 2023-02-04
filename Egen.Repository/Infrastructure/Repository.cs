using Egen.Database.Database;
using Egen.IRepository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Repository.Infrastructure
{
    public abstract class Repository<T> : IGenericRepository<T> where T : class
    {
        ApplicationDbContext _db;
        public DbSet<T> Table
        {
            get
            {
                return _db.Set<T>();
            }
        }
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task<ICollection<T>> GetAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task AddAsync(T Entity)
        {
            await Table.AddAsync(Entity);
        }

        public void UpdateAsync(T Entity)
        {
            Table.Update(Entity);
        }

        public void DeleteAsync(T Entity)
        {
            Table.Remove(Entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var user = await Table.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync<T1>(T1 entity) where T1 : class
        {
            throw new NotImplementedException();
        }
    }
}
