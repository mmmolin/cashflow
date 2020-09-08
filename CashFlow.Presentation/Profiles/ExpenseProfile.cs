using AutoMapper;
using CashFlow.Core.Entities;
using CashFlow.Presentation.ViewModels;

namespace CashFlow.Presentation.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseViewModel>();
            CreateMap<ExpenseViewModel, Expense>();
        }
    }
}
