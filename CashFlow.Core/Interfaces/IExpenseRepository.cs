using CashFlow.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashFlow.Core.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense, string userId);
        Task<Expense> GetByIdAsync(int id, string userId);
        Task<List<Expense>> GetAllAsync(string userId, string filterYear, string filterMonth);
        Task UpdateAsync(Expense expense, string userId);
        Task DeleteAsync(Expense expense, string userId);
    }
}
