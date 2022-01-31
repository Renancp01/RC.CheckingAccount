using System;
using RC.CheckingAccount.Application.ViewModels;

namespace RC.CheckingAccount.Application.Interfaces
{
    public interface IDebitAppService : IDisposable
    {
        void Add(DebitViewModel clientViewModel);

        void Update(DebitViewModel clientViewModel);

        void Remove(DebitViewModel clientViewModel);
    }
}