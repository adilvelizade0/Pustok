using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.ViewModels;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Features = _context.Features.ToList(),
                Sliders = _context.Sliders.ToList(),
                Promotions = _context.Promotions.ToList(),
                PromotionTwos =  _context.PromotionTwos.ToList()
            };
            return View(homeViewModel);
        }
    }
}