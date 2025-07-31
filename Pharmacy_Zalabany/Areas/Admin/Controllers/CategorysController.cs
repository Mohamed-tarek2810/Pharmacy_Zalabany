using Microsoft.AspNetCore.Mvc;
using Pharmacy_Zalabany.Data;
using Pharmacy_Zalabany.Models;

namespace Pharmacy_Zalabany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategorysController : Controller
    {
        private readonly ApplicationDbContext _context = new();

        public IActionResult Index()
        {
            var Categorys = _context.Categorys.ToList();
            return View(Categorys);
        }

        [HttpGet]
        public IActionResult Index1()//create page 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index1(Categorys Categorys)//create page 
        {

            _context.Add(Categorys);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var Categorys = _context.Categorys.Find(id);

            return View(Categorys);
        }
        //return RedirectToAction(actionMame: "NotFoundPage", controllertumo: "Home"); 

        [HttpPost]
        public IActionResult Edit(Categorys Categorys)
        {
            _context.Update(Categorys);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete([FromRoute] int id)
        {
            var Categorys = _context.Categorys.Find(id);

            if (Categorys is not null)
            {
                _context.Remove(Categorys);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
