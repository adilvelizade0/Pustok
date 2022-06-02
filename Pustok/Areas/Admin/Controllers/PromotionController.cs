using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;

namespace Fiorello.Areas.Admin.Controllers
{
    public class Promotion : Controller
    {
        private readonly AppDbContext _context;

        public Promotion(AppDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            List<Pustok.DAL.Models.Promotion> promotions = _context.Promotions.Where(f => !f.IsDeleted).ToList();
            return View(promotions);
        }
        public IActionResult Details(int id)
        {
            Pustok.DAL.Models.Promotion promotion = _context.Promotions.Where(f => f.Id == id).FirstOrDefault();
            return View(promotion);
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            Pustok.DAL.Models.Promotion promotion = _context.Promotions.Where(f => f.Id == id).FirstOrDefault();
            return View(promotion);
        }
        
        [HttpPost]
        public IActionResult Update(int id,string imgUrl,string redirectUrl)
        {
            Pustok.DAL.Models.Promotion promotion = _context.Promotions.Where(f => f.Id == id).FirstOrDefault();
            promotion.ImgUrl = imgUrl;
            promotion.RedirectUrl = redirectUrl;
            _context.Promotions.Update(promotion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Pustok.DAL.Models.Promotion promotion = _context.Promotions.Where(f => f.Id == id).FirstOrDefault();
            promotion.IsDeleted = true;
            _context.Promotions.Update(promotion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Pustok.DAL.Models.Promotion promotion)
        {
            _context.Promotions.Add(promotion);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}