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
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public async Task AddAsync(Expense expense, string userId)
        {
            var parameters = new { description = expense.Description, amount = expense.Amount, dueDate = expense.DueDate, ownerId = userId };
            var sql = "INSERT INTO expense (description, amount, due_date, owner_id) VALUES(@description, @amount, @dueDate, @ownerId)";
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteAsync(Expense expense, string userId)
        {
            var parameter = new { id = expense.Id, ownerId = userId };
            var sql = "DELETE FROM expense WHERE id = @id AND owner_id = @ownerId";
            await connection.ExecuteAsync(sql, parameter);
        }

        public async Task<Expense> GetByIdAsync(int id, string userId)
        {
            var parameter = new { id = id, ownerId = userId };
            var sql = "SELECT * FROM expense WHERE id = @id AND owner_id = @ownerId";
            var entity = await connection.QueryFirstOrDefaultAsync<Expense>(sql, parameter);
            return entity;
        }

        public async Task<List<Expense>> GetAllAsync(string userId)
        {
            var parameter = new { ownerId = userId };
            string sql = "SELECT * FROM expense WHERE owner_id = @ownerId";
            var entities = await connection.QueryAsync<Expense>(sql, parameter);
            return entities.ToList();
        }

        public async Task UpdateAsync(Expense expense, string userId)
        {
            var parameters = new { id = expense.Id, description = expense.Description, amount = expense.Amount, dueDate = expense.DueDate, ownerId = userId };
            var sql = "UPDATE expense SET description = @description, amount = @amount, due_date = @dueDate WHERE id = @Id AND owner_id = @ownerId";
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
