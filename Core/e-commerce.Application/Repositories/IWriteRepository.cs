using e_commerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
    {
        Task<int> SaveAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entity);
        bool Remove(T entity);
        Task<bool> Remove(string id);
        bool RemoveRange(List<T> entity);
        bool UpdateAsync(T entity);
 
    }
}
