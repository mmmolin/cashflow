using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.Data
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private readonly IDbConnection connection;
        public ExpenditureRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task AddAsync(Expenditure expenditure)
        {
            var parameters = new { description = expenditure.Description, amount = expenditure.Amount };
            var sql = "INSERT INTO expenditure (description, amount) VALUES(@description, @amount)";
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteAsync(Expenditure expenditure)
        {
            var parameter = new { Id = expenditure.Id };
            var sql = "DELETE expenditure WHERE id = @Id";
            await connection.ExecuteAsync(sql, parameter);
        }

        public async Task<Expenditure> GetByIdAsync(int id)
        {
            var parameter = new { Id = id };
            var sql = "SELECT * FROM expenditure WHERE id = @Id";
            var entity = await connection.QueryFirstOrDefaultAsync<Expenditure>(sql, parameter);
            return entity;
        }

        public async Task<List<Expenditure>> GetAllAsync()
        {
            string sql = "SELECT * FROM expenditure";
            var entities = await connection.QueryAsync<Expenditure>(sql);
            return entities.ToList();
        }

        public async Task UpdateAsync(Expenditure expenditure)
        {
            var parameters = new { Id = expenditure.Id, Description = expenditure.Description, Amount = expenditure.Amount };
            var sql = "UPDATE expenditure SET description = @Description, amount = @Amount WHERE id = @Id";
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
