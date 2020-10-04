using CashFlow.Presentation.Models;
using System.Collections.Generic;

namespace CashFlow.Presentation.ViewModels
{
    public class ExpenseViewModel
    {
        public ExpenseViewModel()
        {
            Expenses = new List<ExpenseModel>();
        }

        public List<ExpenseModel> Expenses {get; set;}
        public string Year { get; set; }
        public string Month { get; set; }
    }
}