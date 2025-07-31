using Microsoft.AspNetCore.Mvc;
using Pharmacy_Zalabany.Data;
using Pharmacy_Zalabany.Models;

namespace Pharmacy_Zalabany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotesController : Controller
    {

        private readonly ApplicationDbContext _context = new();
        
        public ApplicationDbContext Context => _context;

        public IActionResult Index()
        {
            var Notes = Context.Notes.ToList();
            return View(Notes);
        }

        [HttpGet]
        public IActionResult Index1()//create page 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index1(Notes note)//create page 
        {

            Context.Add(note);
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var Notes = Context.Notes.Find(id);

            return View(Notes);
        }
        //return RedirectToAction(actionMame: "NotFoundPage", controllertumo: "Home"); 

        [HttpPost]
        public IActionResult Edit(Notes note)
        {
            Context.Update(note);
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete([FromRoute] int id)
        {
            var Notes = Context.Notes.Find(id);

            if (Notes is not null)
            {
                Context.Remove(Notes);
                Context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

    }
}

