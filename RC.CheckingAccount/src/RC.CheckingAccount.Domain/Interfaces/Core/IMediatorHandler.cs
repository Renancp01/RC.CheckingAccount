using System.Threading.Tasks;
using RC.CheckingAccount.Domain.Commom;

namespace RC.CheckingAccount.Domain.Interfaces.Core
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}