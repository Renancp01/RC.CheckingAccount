using System;
using System.Threading.Tasks;
using AutoMapper;
using RC.CheckingAccount.Application.Interfaces;
using RC.CheckingAccount.Application.ViewModels;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Interfaces.Core;

namespace RC.CheckingAccount.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;

        public ClientAppService(IMediatorHandler bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        public async Task Add(ClientViewModel clientViewModel)
        {
            var command = _mapper.Map<CreateClientCommand>(clientViewModel);

            await _bus.SendCommand(command);
        }

        public async Task Update(ClientViewModel clientViewModel)
        {
            var command = _mapper.Map<UpdateClientCommand>(clientViewModel);

            await _bus.SendCommand(command);
        }

        public async Task Remove(ClientViewModel clientViewModel)
        {
            var command = _mapper.Map<RemoveClientCommand>(clientViewModel);

            await _bus.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}