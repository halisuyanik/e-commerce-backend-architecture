using e_commerce.Application.Repositories;
using e_commerce.Domain.Entities.Common;
using e_commerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Persistence.Repositories
{
    public class EfEntityWriteRepositoryBase<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly dbContext _context;


        public EfEntityWriteRepositoryBase(dbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public DbSet<TEntity> Table => _context.Set < TEntity >();

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry= await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
            
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }

        public bool Remove(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry=Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> Remove(string id)
        {
            TEntity entity=await Table.FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));
            return Remove(entity);
        }
        public bool RemoveRange(List<TEntity> entity)
        {
            Table.RemoveRange(entity);
            return true;
        }
        public bool UpdateAsync(TEntity entity)
        {
            EntityEntry entityEntry= Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        
    }
}
