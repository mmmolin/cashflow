using CashFlow.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashFlow.Core.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
        Task<Expense> GetByIdAsync(int id);
        Task<List<Expense>> GetAllAsync();
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(Expense expense);
    }
}
