using System;
using RC.CheckingAccount.Application.ViewModels;

namespace RC.CheckingAccount.Application.Interfaces
{
    public interface ICreditAppService : IDisposable
    {
        void Add(CreditViewModel clientViewModel);

        void Update(CreditViewModel clientViewModel);

        void Remove(CreditViewModel clientViewModel);
    }
}