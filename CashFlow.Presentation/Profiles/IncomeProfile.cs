using AutoMapper;
using CashFlow.Core.Entities;
using CashFlow.Presentation.Models;

namespace CashFlow.Presentation.Profiles
{
    public class IncomeProfile : Profile
    {
        public IncomeProfile()
        {
            CreateMap<Income, IncomeModel>();
            CreateMap<IncomeModel, Income>();
        }
    }
}
