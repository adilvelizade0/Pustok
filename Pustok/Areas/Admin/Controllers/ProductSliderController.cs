using System;
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
            List<Product> products = _context.Products.Where(p => !p.IsDeleted).Include(p => p.Author).ToList();
            return View(products);
        }
        
        public IActionResult Details(int id)
        {
            List<Product> product = _context.Products.Where(p => p.Id == id).Include(p => p.Author).ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = _context.Products.Where(p => p.Id == id).Include(p => p.Author).FirstOrDefault();
            return View(product);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id,string productName,decimal productCostPrice,decimal productSalePrice,decimal productDiscountPrice)
        {
            Product product = _context.Products.Where(p => p.Id == id).Include(p => p.Author).FirstOrDefault();
            if (product is null || string.IsNullOrEmpty(productName.Trim()))
            {
                return NotFound();
            }
            product.Name = String.Join(" ", productName.Split("+"));
            product.CostPrice = (double)productCostPrice;
            product.SalePrice = (double)productSalePrice;
            product.DiscountPrice = (double)productDiscountPrice;
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            Author author = new Author();
            Category category = new Category();
            author.Fullname = "Adil Valizada";
            category.Name = "Action";
            product.IsFeatured = false;
            product.IsNew = true;
            product.Author = author;
            product.Category = category;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Where(p => p.Id == id).Include(p => p.Author).FirstOrDefault();
            product.IsDeleted = true;
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}