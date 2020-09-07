using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CashFlow.Infrastructure.Data
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private readonly IDbConnection connection;
        public ExpenditureRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Add(Expenditure expenditure)
        {
            var parameters = new { description = expenditure.Description, amount = expenditure.Amount };
            var sql = "INSERT INTO expenditure (description, amount) VALUES(@description, @amount)";
            connection.Execute(sql, parameters);
        }

        public void Delete(Expenditure expenditure)
        {
            var parameter = new { Id = expenditure.Id };
            var sql = "DELETE expenditure WHERE id = @Id";
            connection.Execute(sql, parameter);
        }

        public Expenditure GetById(int id)
        {
            var parameter = new { Id = id };
            var sql = "SELECT * FROM expenditure WHERE id = @Id";
            var entity = connection.Query<Expenditure>(sql, parameter).FirstOrDefault();
            return entity;
        }

        public List<Expenditure> GetAll()
        {
            string sql = "SELECT * FROM expenditure";
            var entities = connection.Query<Expenditure>(sql).ToList();
            return entities;
        }

        public void Update(Expenditure expenditure)
        {
            var parameters = new { Id = expenditure.Id, Description = expenditure.Description, Amount = expenditure.Amount };
            var sql = "UPDATE expenditure SET description = @Description, amount = @Amount WHERE id = @Id";
            connection.Execute(sql, parameters);
        }
    }
}
