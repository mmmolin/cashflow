using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using CashFlow.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CashFlow.Presentation.Controllers
{
    public class ExpenditureController : Controller
    {
        private readonly IExpenditureRepository db;
        public ExpenditureController(IExpenditureRepository expenditureRepository)
        {
            this.db = expenditureRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var expenditures = db.GetAll();
            return View(expenditures);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExpenditureViewModel expenditure)
        {
            if(ModelState.IsValid)
            {
                var entity = new Expenditure
                {
                    Description = expenditure.Description,
                    Amount = expenditure.Amount
                };

                db.Add(entity);

                return RedirectToAction("Index");
            }

            return View(expenditure);
        }

        public IActionResult Details()
        {
            return null;
        }

        public IActionResult Update()
        {
            return null;
        }

        public IActionResult Delete()
        {
            return null;
        }
    }
}
