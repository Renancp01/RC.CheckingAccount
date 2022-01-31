using AutoMapper;
using RC.CheckingAccount.Application.ViewModels;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Commands.Credit;
using RC.CheckingAccount.Domain.Commands.Debit;

namespace RC.CheckingAccount.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Client
            CreateMap<ClientViewModel, CreateClientCommand>()
                .ConstructUsing(c => new CreateClientCommand(c.Name, c.LastName));

            CreateMap<ClientViewModel, UpdateClientCommand>()
                .ConstructUsing(c => new UpdateClientCommand(c.Id, c.Name, c.LastName));

            CreateMap<ClientViewModel, RemoveClientCommand>()
                .ConstructUsing(c => new RemoveClientCommand(c.Id));

            //Credit
            CreateMap<CreditViewModel, CreateCreditCommand>()
                .ConstructUsing(c => new CreateCreditCommand(c.ClientId, c.Value));

            CreateMap<CreditViewModel, UpdateCreditCommand>()
                .ConstructUsing(c => new UpdateCreditCommand(c.Id, c.Value));

            CreateMap<CreditViewModel, RemoveCreditCommand>()
                .ConstructUsing(c => new RemoveCreditCommand(c.Id));

            //Debit
            CreateMap<DebitViewModel, CreateDebitCommand>()
                .ConstructUsing(c => new CreateDebitCommand(c.ClientId, c.Value));

            CreateMap<DebitViewModel, UpdateDebitCommand>()
                .ConstructUsing(c => new UpdateDebitCommand(c.Id, c.Value));

            CreateMap<DebitViewModel, RemoveDebitCommand>()
                .ConstructUsing(c => new RemoveDebitCommand(c.Id));

        }
    }
}
