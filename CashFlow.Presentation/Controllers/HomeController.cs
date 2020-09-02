using Microsoft.AspNetCore.Mvc;


namespace CashFlow.Presentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
