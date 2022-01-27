using RC.CheckingAccount.Domain.CommandsHandlers.Core;

namespace RC.CheckingAccount.Domain.Events.Core
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}