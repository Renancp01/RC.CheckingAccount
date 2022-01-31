using RC.CheckingAccount.Domain.Entities;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Repository.Context;

namespace RC.CheckingAccount.Repository.Respositories
{
    public class CreditRepository :Respository<Credit>, ICreditRepository
    {
        public CreditRepository(CheckingAccountContext context) : base(context)
        {
        }
    }
}