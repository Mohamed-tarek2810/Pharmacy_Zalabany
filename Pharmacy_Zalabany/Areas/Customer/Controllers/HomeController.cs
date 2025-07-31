using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Pharmacy_Zalabany.Data;
using Pharmacy_Zalabany.Models;

namespace Pharmacy_Zalabany.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context = new();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        var products = _context.Products.Take(4).ToList();
        var notes = _context.Notes.ToList();

        if (products.Any())
        {
            var Relatedandtop = new RelatedandtopVm
            {
                product = products,
                Notes = notes
            };

            return View(Relatedandtop);
        }

        return NotFound();

    }

    public IActionResult Products()
    {
        var products = _context.Products.Include(e=>e.Category).ToList();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products
       
            .FirstOrDefault(p => p.ProductId == id);

        if (product == null)
            return NotFound(); 

        return View(product);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
