using System;
using System.Collections.Generic;
using System.Text;

namespace CashFlow.Core.Interfaces
{
    interface IExpenditureRepository
    {
        void AddExpenditure();
        void GetExpenditureById();
        void UpdateExpenditure();
        void DeleteExpenditure();
    }
}
