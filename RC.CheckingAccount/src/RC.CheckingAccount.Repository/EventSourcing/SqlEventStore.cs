using RC.CheckingAccount.Domain.Commom;
using RC.CheckingAccount.Domain.Events.Core;

namespace RC.CheckingAccount.Repository.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        public void Save<T>(T theEvent) where T : Event
        {
            throw new System.NotImplementedException();
        }
    }
}