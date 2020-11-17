using CashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashFlow.Core.Services
{
    public class ChartService
    {
        public decimal[] CalculateIncomeExpenseTotal(IEnumerable<Income> incomeData, IEnumerable<Expense> expenseData)
        {
            decimal incomeAmount = 0;
            foreach(var income in incomeData)
            {
                incomeAmount += income.Amount;
            }

            decimal expenseAmount = 0;
            foreach(var expense in expenseData)
            {
                expenseAmount += expense.Amount;
            }

            decimal[] incomeExpenseTotal = new decimal[] { 0, 0 };
            incomeExpenseTotal[0] += incomeAmount;
            incomeExpenseTotal[1] += expenseAmount;

            return incomeExpenseTotal;
        }
    }
}
