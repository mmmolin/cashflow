using CashFlow.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CashFlow.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IIncomeRepository incomeRepository;
        private IExpenseRepository expenseRepository;

        public HomeController(IIncomeRepository incomeRepository, IExpenseRepository expenseRepository)
        {
            incomeRepository = this.incomeRepository;
            expenseRepository = this.expenseRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
