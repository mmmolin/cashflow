using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Core.Interfaces;
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
