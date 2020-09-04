using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace CashFlow.Infrastructure.Data
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private readonly IDbConnection db;
        public ExpenditureRepository(IDbConnection db)
        {
            this.db = db;
        }

        public void Add(Expenditure expenditure)
        {
            //db.Add(expenditure);
        }

        public void Delete(Expenditure expenditure)
        {
            //db.Remove(expenditure);
        }

        public Expenditure GetById(int id)
        {
            return new Expenditure();
            //return db.Where(x => x.Id == id).First();
        }

        public List<Expenditure> GetAll()
        {
            return new List<Expenditure>();
            //return db;
        }

        public void Update(Expenditure expenditure)
        {
            //db.Select(x => x = expenditure).Where(x => x.Id == expenditure.Id).First();

        }
    }
}
