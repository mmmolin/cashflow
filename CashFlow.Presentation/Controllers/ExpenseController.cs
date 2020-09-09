using AutoMapper;
using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using CashFlow.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CashFlow.Presentation.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository db;
        private readonly IMapper mapper;
        public ExpenseController(IMapper mapper, IExpenseRepository expenseRepository)
        {
            this.db = expenseRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var expenses =  await db.GetAllAsync();
            return View(expenses);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseViewModel expense)
        {
            if(ModelState.IsValid)
            {
                var entity = mapper.Map<Expense>(expense);
                await db.AddAsync(entity);

                return RedirectToAction("Index");
            }

            return View(expense);
        }

        public async Task<IActionResult> Details()
        {
            // Nullcheck
            return null;
        }

        public async Task<IActionResult> Update(int id)
        {
            var expense = await db.GetByIdAsync(id);
            if (expense != null) 
            {
                var expenseViewModel = mapper.Map<ExpenseViewModel>(expense);
                return View(expenseViewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExpenseViewModel expense)
        {
            if(ModelState.IsValid)
            {
                var entity = mapper.Map<Expense>(expense);
                await db.UpdateAsync(entity);

                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var expense = await db.GetByIdAsync(id);
            if(expense != null)
            {
                await db.DeleteAsync(expense);
            }

            return RedirectToAction("Index");
        }
    }
}
