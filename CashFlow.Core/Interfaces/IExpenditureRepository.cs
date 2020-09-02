using CashFlow.Core.Entities;
using System.Collections.Generic;

namespace CashFlow.Core.Interfaces
{
    public interface IExpenditureRepository
    {
        void Add(Expenditure expenditure);
        Expenditure GetById(int id);
        List<Expenditure> GetAll();
        void Update(Expenditure expenditure);
        void Delete(Expenditure expenditure);
    }
}
