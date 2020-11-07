using AutoMapper;
using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using CashFlow.Presentation.Models;
using CashFlow.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CashFlow.Presentation.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeRepository db;
        private readonly IMapper mapper;
        public IncomeController(IMapper mapper, IIncomeRepository incomeRepository)
        {
            this.db = incomeRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month.ToString();
            var entity = await db.GetAllAsync(userId, year, month);
            var income = mapper.Map<List<IncomeModel>>(entity);
            var viewModel = new IncomeViewModel();
            viewModel.Income = income;
            viewModel.Year = year;
            viewModel.Month = month;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(IFormCollection collection)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var year = collection["Year"].FirstOrDefault();
            var month = collection["Month"].FirstOrDefault();
            var entity = await db.GetAllAsync(userId, year, month);
            var income = mapper.Map<List<IncomeModel>>(entity);
            var viewModel = new IncomeViewModel();
            viewModel.Income = income;
            viewModel.Year = year;
            viewModel.Month = month;
            return View(viewModel);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(IncomeModel income)
        {
            if(ModelState.IsValid)
            {
                var entity = mapper.Map<Income>(income);
                entity.OwnerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await db.AddAsync(entity);

                return RedirectToAction("Index");
            }

            return View(income);
        }

        public async Task<ActionResult> Update(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var entity = await db.GetByIdAsync(id, userId);
            if(entity != null)
            {
                var model = mapper.Map<IncomeModel>(entity);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Update(IncomeModel income)
        {
            if(ModelState.IsValid)
            {
                var entity = mapper.Map<Income>(income);
                entity.OwnerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await db.UpdateAsync(entity);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var entity = await db.GetByIdAsync(id, userId);
            if(entity != null)
            {
                await db.DeleteAsync(entity);
            }
            return RedirectToAction("Index");
        }
    }
}
