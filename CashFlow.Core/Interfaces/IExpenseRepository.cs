using CashFlow.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashFlow.Core.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expenditure);
        Task<Expense> GetByIdAsync(int id);
        Task<List<Expense>> GetAllAsync();
        Task UpdateAsync(Expense expenditure);
        Task DeleteAsync(Expense expenditure);
    }
}
