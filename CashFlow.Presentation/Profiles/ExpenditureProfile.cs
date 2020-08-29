using AutoMapper;
using CashFlow.Core.Entities;
using CashFlow.Presentation.ViewModels;

namespace CashFlow.Presentation.Profiles
{
    public class ExpenditureProfile : Profile
    {
        public ExpenditureProfile()
        {
            CreateMap<Expenditure, ExpenditureViewModel>();
            CreateMap<ExpenditureViewModel, Expenditure>();
        }
    }
}
