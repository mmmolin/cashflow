using CashFlow.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashFlow.Core.Interfaces
{
    public interface IExpenditureRepository
    {
        Task AddAsync(Expenditure expenditure);
        Task<Expenditure> GetByIdAsync(int id);
        Task<List<Expenditure>> GetAllAsync();
        Task UpdateAsync(Expenditure expenditure);
        Task DeleteAsync(Expenditure expenditure);
    }
}
