using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;


namespace Fiorello.Areas.Admin.Controllers
{
    public class Feature : Controller
    {
        private readonly AppDbContext _context;

        public Feature(AppDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            List<Pustok.DAL.Models.Feature> features = _context.Features.Where(f => !f.IsDeleted).ToList();
            return View(features);
        }
        
        public IActionResult Details(int id)
        {
            Pustok.DAL.Models.Feature feature = _context.Features.Where(f => f.Id == id).FirstOrDefault();
            return View(feature);
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            Pustok.DAL.Models.Feature feature = _context.Features.Where(f => f.Id == id).FirstOrDefault();
            return View(feature);
        }
        
        [HttpPost]
        public IActionResult Update(int id,string title,string subtitle,string iconUrl)
        {
            Pustok.DAL.Models.Feature feature = _context.Features.Where(f => f.Id == id).FirstOrDefault();
            feature.Title = title;
            feature.IconUrl = iconUrl;
            feature.SubTitle = subtitle;
            _context.Features.Update(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Pustok.DAL.Models.Feature feature = _context.Features.Where(f => f.Id == id).FirstOrDefault();
            feature.IsDeleted = true;
            _context.Features.Update(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Pustok.DAL.Models.Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}