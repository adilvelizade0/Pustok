using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Areas.Admin.Controllers
{
    public class Dashboard : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}