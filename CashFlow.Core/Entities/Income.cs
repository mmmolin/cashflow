using System;

namespace CashFlow.Core.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Registered { get; set; }
        public string OwnerId { get; set; }
    }
}
