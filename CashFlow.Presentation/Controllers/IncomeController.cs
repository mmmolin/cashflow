using AutoMapper;
using CashFlow.Core.Interfaces;
using CashFlow.Presentation.Models;
using CashFlow.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
