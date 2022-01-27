using System.Threading.Tasks;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Repository.Context;

namespace RC.CheckingAccount.Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.CheckingAccountContext _context;

        public UnitOfWork(CheckingAccountContext context)
        {
            _context = context;
        }

        public async void Dispose()
        {
           await _context.DisposeAsync().ConfigureAwait(false);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}