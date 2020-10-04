using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Presentation.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
    }
}
