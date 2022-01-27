using RC.CheckingAccount.Domain.Entities;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Repository.Context;

namespace RC.CheckingAccount.Repository.Respositories
{
    public class ClientRepository : Respository<Client>, IClientRepository
    {
        public ClientRepository(CheckingAccountContext context) : base(context)
        {
        }
    }
}