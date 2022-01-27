using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Repository.Context;

namespace RC.CheckingAccount.Repository.Respositories
{
    public abstract class Respository<T> : IRepository<T> where T : class
    {
        protected CheckingAccountContext Db;
        protected DbSet<T> DbSet;

        public Respository(CheckingAccountContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}