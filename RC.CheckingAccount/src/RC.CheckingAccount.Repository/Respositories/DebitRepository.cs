using RC.CheckingAccount.Domain.Entities;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Repository.Context;

namespace RC.CheckingAccount.Repository.Respositories
{
    public class DebitRepository : Respository<Debit>, IDebitRepository
    {
        public DebitRepository(CheckingAccountContext context) : base(context)
        {
        }
    }
}