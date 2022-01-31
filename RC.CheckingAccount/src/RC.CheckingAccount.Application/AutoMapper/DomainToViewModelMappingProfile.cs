using AutoMapper;
using RC.CheckingAccount.Application.ViewModels;
using RC.CheckingAccount.Domain.Entities;

namespace RC.CheckingAccount.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<Debit, DebitViewModel>();
            CreateMap<Credit, CreditViewModel>();
        }
    }
}
