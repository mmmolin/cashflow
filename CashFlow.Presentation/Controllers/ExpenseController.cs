using AutoMapper;
using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using CashFlow.Presentation.Models;
using CashFlow.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month.ToString();
            var viewModel = new ExpenseViewModel() { Year = year, Month = month };
            var entities = await db.GetAllAsync(userId, year, month);
            foreach (var entity in entities)
            {
                var expense = mapper.Map<ExpenseModel>(entity);
                viewModel.Expenses.Add(expense);
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var year = collection["Year"].FirstOrDefault();
            var month = collection["Month"].FirstOrDefault();
            var viewModel = new ExpenseViewModel() { Year = year, Month = month };
            var entities = await db.GetAllAsync(userId, year, month);
            foreach (var entity in entities)
            {
                var expense = mapper.Map<ExpenseModel>(entity);
                viewModel.Expenses.Add(expense);
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseModel expense)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<Expense>(expense);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await db.AddAsync(entity, userId);

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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var expense = await db.GetByIdAsync(id, userId);
            if (expense != null)
            {
                var expenseViewModel = mapper.Map<ExpenseViewModel>(expense);
                return View(expenseViewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExpenseModel expense)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<Expense>(expense);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await db.UpdateAsync(entity, userId);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var expense = await db.GetByIdAsync(id, userId);
            if (expense != null)
            {
                await db.DeleteAsync(expense, userId);
            }

            return RedirectToAction("Index");
        }
    }
}
