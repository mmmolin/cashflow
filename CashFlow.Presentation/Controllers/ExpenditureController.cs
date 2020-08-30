using AutoMapper;
using CashFlow.Core.Entities;
using CashFlow.Core.Interfaces;
using CashFlow.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CashFlow.Presentation.Controllers
{
    public class ExpenditureController : Controller
    {
        private readonly IMapper mapper;
        private readonly IExpenditureRepository db;
        public ExpenditureController(IMapper mapper, IExpenditureRepository expenditureRepository)
        {
            this.mapper = mapper;
            this.db = expenditureRepository;
        }

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
                var entity = mapper.Map<Expenditure>(expenditure);
                db.Add(entity);

                return RedirectToAction("Index");
            }

            return View(expenditure);
        }

        public IActionResult Details()
        {
            return null;
        }

        public IActionResult Update(int id)
        {
            var expenditure = db.GetById(id);
            var expenditureViewModel = mapper.Map<ExpenditureViewModel>(expenditure);

            return View(expenditureViewModel);
        }

        [HttpPost]
        public IActionResult Update(ExpenditureViewModel expenditure)
        {
            if(ModelState.IsValid)
            {
                var entity = mapper.Map<Expenditure>(expenditure);
                db.Update(entity);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var expenditure = db.GetById(id);
            db.Delete(expenditure);
            return RedirectToAction("Index");
        }
    }
}
