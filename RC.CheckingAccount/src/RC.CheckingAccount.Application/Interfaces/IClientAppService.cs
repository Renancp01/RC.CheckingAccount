using System;
using System.Threading.Tasks;
using RC.CheckingAccount.Application.ViewModels;

namespace RC.CheckingAccount.Application.Interfaces
{
    public interface IClientAppService : IDisposable
    {
        Task Add(ClientViewModel clientViewModel);
        
        Task Update(ClientViewModel clientViewModel);
        
        Task Remove(ClientViewModel clientViewModel);
    }
}