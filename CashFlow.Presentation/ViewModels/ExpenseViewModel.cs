using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Presentation.ViewModels
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
    }
}
