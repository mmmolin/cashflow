using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.Data
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IDbConnection connection;
        public ExpenseRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task AddAsync(Expense expense)
        {
            var parameters = new { description = expense.Description, amount = expense.Amount };
            var sql = "INSERT INTO expense (description, amount) VALUES(@description, @amount)";
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteAsync(Expense expense)
        {
            var parameter = new { Id = expense.Id };
            var sql = "DELETE expense WHERE id = @Id";
            await connection.ExecuteAsync(sql, parameter);
        }

        public async Task<Expense> GetByIdAsync(int id)
        {
            var parameter = new { Id = id };
            var sql = "SELECT * FROM expense WHERE id = @Id";
            var entity = await connection.QueryFirstOrDefaultAsync<Expense>(sql, parameter);
            return entity;
        }

        public async Task<List<Expense>> GetAllAsync()
        {
            string sql = "SELECT * FROM expense";
            var entities = await connection.QueryAsync<Expense>(sql);
            return entities.ToList();
        }

        public async Task UpdateAsync(Expense expense)
        {
            var parameters = new { Id = expense.Id, Description = expense.Description, Amount = expense.Amount };
            var sql = "UPDATE expense SET description = @Description, amount = @Amount WHERE id = @Id";
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
