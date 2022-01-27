using System;
using System.Threading.Tasks;

namespace RC.CheckingAccount.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}