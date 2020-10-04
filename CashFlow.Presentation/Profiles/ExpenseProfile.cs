using AutoMapper;
using CashFlow.Core.Entities;
using CashFlow.Presentation.Models;

namespace CashFlow.Presentation.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseModel>();
            CreateMap<ExpenseModel, Expense>();
        }
    }
}
