using Microsoft.AspNetCore.Mvc;
using Pharmacy_Zalabany.Data;
using Pharmacy_Zalabany.Models;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy_Zalabany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context = new();

        public IActionResult Index()
        {
            var product = _context.Products.ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult Index1()//create page 
        {
            var Categorys = _context.Categorys;

            CategoriesAndProductsvm CategoriesAndProductsvm= new()
            {
                Categorys = Categorys.ToList()

            };
            return View(CategoriesAndProductsvm);
        }
        [HttpPost]
        public IActionResult Index1(Products product)//create page 
        {

            _context.Add(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var Products = _context.Products.Find(id);

            return View(Products);
        }
        //return RedirectToAction(actionMame: "NotFoundPage", controllertumo: "Home"); 

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete([FromRoute] int id)
        {
            var Products = _context.Products.Find(id);

            if (Products is not null)
            {
                _context.Remove(Products);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
