using System;
using System.Collections.Generic;
using System.Text;

namespace CashFlow.Core.Entities
{
    public class Expenditure
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
