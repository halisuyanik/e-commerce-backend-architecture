using e_commerce.Application.Repositories;
using e_commerce.Domain.Entities.Common;
using e_commerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Persistence.Repositories
{
    public class EfEntityReadRepositoryBase<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly dbContext _context;

        public EfEntityReadRepositoryBase(dbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> GetAll( bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();

            }
            return query;
        }

        public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));
        }
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();

            }
            return await query.FirstOrDefaultAsync(filter);
        }
        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.Where(filter);
            if (!tracking)
            {
                query = query.AsNoTracking();

            }
            return query;
        }
    }
}
