using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CashFlow.Infrastructure.Data
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private List<Expenditure> db;
        public ExpenditureRepository()
        {
            InMemoryData();
        }

        public void Add(Expenditure expenditure)
        {
            db.Add(expenditure);
        }

        public void Delete(Expenditure expenditure)
        {
            db.Remove(expenditure);
        }

        public Expenditure GetById(int id)
        {
            return db.Where(x => x.Id == id).First();
        }

        public List<Expenditure> GetAll()
        {
            return db;
        }

        public void Update(Expenditure expenditure)
        {
            db.Select(x => x = expenditure).Where(x => x.Id == expenditure.Id).First();

        }

        // Temp
        private void InMemoryData()
        {
            db = new List<Expenditure>() 
            { 
                new Expenditure 
                { 
                    Id = 1,
                    Description = "Telia Bredband",
                    Amount = 512
                },
                new Expenditure
                {
                    Id = 2,
                    Description = "Västtrafik månadskort",
                    Amount = 1400
                },
                new Expenditure
                {
                    Id = 3,
                    Description = "Huslån, Swedbank",
                    Amount = 6000
                }
            };
        }
    }
}
