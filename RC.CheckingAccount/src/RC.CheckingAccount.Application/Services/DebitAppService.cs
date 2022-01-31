using System;
using AutoMapper;
using RC.CheckingAccount.Application.Interfaces;
using RC.CheckingAccount.Application.ViewModels;
using RC.CheckingAccount.Domain.Commands.Debit;
using RC.CheckingAccount.Domain.Interfaces.Core;

namespace RC.CheckingAccount.Application.Services
{
    public class DebitAppService : IDebitAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;

        public DebitAppService(IMediatorHandler bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        public void Add(DebitViewModel viewModel)
        {
            var command = _mapper.Map<CreateDebitCommand>(viewModel);

            _bus.SendCommand(command);
        }

        public void Update(DebitViewModel viewModel)
        {
            var command = _mapper.Map<UpdateDebitCommand>(viewModel);

            _bus.SendCommand(command);
        }

        public void Remove(DebitViewModel viewModel)
        {
            var command = _mapper.Map<RemoveDebitCommand>(viewModel);

            _bus.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}