using CashFlow.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashFlow.Core.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense, string userId);
        Task<Expense> GetByIdAsync(int id, string userId);
        Task<List<Expense>> GetAllByMonthAsync(string userId, string filterYear, string filterMonth);
        Task<List<Expense>> GetAllByYearAsync(string userId, string filterYear);
        Task UpdateAsync(Expense expense, string userId);
        Task DeleteAsync(Expense expense, string userId);
    }
}
