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
            var product = _context.Products.Include(e=>e.Category).ToList();
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
        public IActionResult Index1(Products Products, IFormFile MainImg)
        {
            if(MainImg is not null && MainImg.Length > 0)
            {
               var fileNmae = Guid.NewGuid().ToString() + Path.GetExtension(MainImg.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img\\portfolio", fileNmae);

                using (var stream = System.IO.File.Create(filePath))
                {
                    MainImg.CopyTo(stream);
                }

                Products.MainImg = fileNmae;

                _context.Add(Products);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return BadRequest();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();

            var categorys = _context.Categorys.ToList();

            var CategoriesAndProducts = new CategoriesAndProductsvm
            {
                Product = product,
                Categorys = categorys
            };

            return View(CategoriesAndProducts); 
        }



        [HttpPost]
        public IActionResult Edit(Products Products, IFormFile MainImg)
        {
            var productInDB = _context.Products.AsNoTracking()
         .FirstOrDefault(e => e.ProductId == Products.ProductId);
            if (productInDB is not null)
            {
                if (MainImg is not null && MainImg.Length > 0)
                {
                    var fileNmae = Guid.NewGuid().ToString() + Path.GetExtension(MainImg.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img\\portfolio", fileNmae);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        MainImg.CopyTo(stream);
                    }
                    // Delete old img from wwroot
                    var oldFilePath  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img\\portfolio"
                        , productInDB.MainImg);
                    if (System.IO.File.Exists(productInDB.MainImg)) 
                    {
                        System.IO.File.Delete(productInDB.MainImg);
                    }

                    //save
                    Products.MainImg = fileNmae;

                }
                else
                {
                    Products.MainImg = productInDB.MainImg;
                }
                _context.Update(Products);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();

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
