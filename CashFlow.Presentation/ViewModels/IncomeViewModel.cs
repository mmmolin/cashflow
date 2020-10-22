using CashFlow.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Presentation.ViewModels
{
    public class IncomeViewModel
    {
        public IncomeViewModel()
        {
            Income = new List<IncomeModel>();
        }

        public List<IncomeModel> Income { get; set; } 
        public string Year { get; set; }
        public string Month { get; set; }
    }
}
