using CashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
