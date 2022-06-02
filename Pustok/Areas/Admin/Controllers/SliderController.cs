using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.DAL.Models;

namespace Fiorello.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.Where(s => !s.IsDeleted).ToList();
            return View(sliders);
        }
        
        public IActionResult Details(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(s => !s.IsDeleted && s.Id == id);
            return View(slider);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(s => !s.IsDeleted && s.Id == id);
            slider.IsDeleted = true;
            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            return View(slider);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id,string title1,string title2,string description,string imageUrl,string redirectText,string redirectUrl)
        {
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            if (slider is null)
            {
                return NotFound();
            }

            slider.Title1 = title1;
            slider.Title2 = title2;
            slider.Description = description;
            slider.ImageUrl = imageUrl;
            slider.RedirectText = redirectText;
            slider.RedirectUrl = redirectUrl;
            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            int order = _context.Sliders.ToList()[_context.Sliders.ToList().Count - 1].Order;
            slider.Order = order + 1;
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}