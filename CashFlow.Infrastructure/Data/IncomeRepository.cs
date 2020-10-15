using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.Data
{
    public class IncomeRepository : IIncomeRepository
    {
        private IDbConnection connection;

        public IncomeRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        public Task AddAsync(Income income, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Income income, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Income>> GetAllAsync(string userId, string filterYear, string filterMonth)
        {
            throw new NotImplementedException();
        }

        public Task<Income> GetByIdAsync(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Income income, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
