using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.CheckingAccount.Domain.Interfaces
{
    public interface IRepository<in T> where T: class
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task RemoveAsync(Guid entity);

        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}