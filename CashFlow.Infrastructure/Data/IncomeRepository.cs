using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.Data
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly IDbConnection connection;

        public IncomeRepository(IDbConnection connection)
        {
            this.connection = connection;
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
        public async Task AddAsync(Income income)
        {
            var parameters = new { description = income.Description, amount = income.Amount, registered = income.Registered, ownerId = income.OwnerId };
            var sql = "INSERT INTO income (description, amount, registered, owner_id) VALUES(@description, @amount, @registered, @ownerId)";
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteAsync(Income income)
        {
            var parameters = new { id = income.Id, ownerId = income.OwnerId };
            var sql = "DELETE FROM income WHERE id = @id AND owner_id = ownerId";
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<Income>> GetAllAsync(string userId, string filterYear, string filterMonth)
        {
            var parameters = new { ownerId = userId, year = filterYear, month = filterMonth };
            var sql = "SELECT * FROM income WHERE owner_id = @ownerId AND EXTRACT(YEAR from registered)::text = @year AND EXTRACT(MONTH from registered)::text = @month";
            var entities = await connection.QueryAsync<Income>(sql, parameters);
            return entities.ToList();
        }

        public async Task<Income> GetByIdAsync(int id, string userId)
        {
            var parameters = new { id = id, ownerId = userId };
            var sql = "SELECT * FROM income WHERE id = @id AND owner_id = @ownerId";
            var entity = await connection.QueryFirstOrDefaultAsync<Income>(sql, parameters);
            return entity;
        }

        public async Task UpdateAsync(Income income)
        {
            var parameters = new { id = income.Id, description = income.Description, amount = income.Amount, registered = income.Registered, ownerId = income.OwnerId };
            var sql = "UPDATE income SET description = @description, amount = @amount, registered = @registered WHERE id = @id AND owner_id = ownerId";
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
