using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.DAL.Models;

namespace Fiorello.Areas.Admin.Controllers
{
    public class ProductSliderController : Controller
    {
        
        private readonly AppDbContext _context;

        public ProductSliderController(AppDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Include(p => p.Author).ToList();
            return View(products);
        }
        
        public IActionResult Details(int id)
        {
           
            return Json(id);
        }
    }
}