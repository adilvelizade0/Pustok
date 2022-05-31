using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                PromotionTwos =  _context.PromotionTwos.ToList(),
                FeaturedProducts = _context.Products.Where(fp => fp.IsFeatured).Include(fp => fp.Author).ToList(),
                NewProduct = _context.Products.Where(fp => fp.IsNew).Include(fp => fp.Author).ToList(),
                DiscountProduct = _context.Products.Where(fp => fp.DiscountPrice > 0).Include(fp => fp.Author).ToList(),
                Categories = _context.Categories.ToList()
            };
            return View(homeViewModel);
        }
    }
}