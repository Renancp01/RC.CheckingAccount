using System;
using AutoMapper;
using RC.CheckingAccount.Application.Interfaces;
using RC.CheckingAccount.Application.ViewModels;
using RC.CheckingAccount.Domain.Commands.Credit;
using RC.CheckingAccount.Domain.Interfaces.Core;

namespace RC.CheckingAccount.Application.Services
{
    public class CreditAppService : ICreditAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;

        public CreditAppService(IMediatorHandler bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        public void Add(CreditViewModel viewModel)
        {
            var command = _mapper.Map<CreateCreditCommand>(viewModel);

            _bus.SendCommand(command);
        }

        public void Update(CreditViewModel viewModel)
        {
            var command = _mapper.Map<UpdateCreditCommand>(viewModel);

            _bus.SendCommand(command);
        }

        public void Remove(CreditViewModel viewModel)
        {
            var command = _mapper.Map<RemoveCreditCommand>(viewModel);

            _bus.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}