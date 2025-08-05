using System.Diagnostics;
using System.Linq;
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

        var products = _context.Products.OrderBy(p => p.ProductId).Take(4).ToList();
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

    public IActionResult Products(ProductFilterVM productFilterVM, int page = 1)
    {
        IQueryable <Products> products = _context.Products.Include(e=>e.Category);

        if (productFilterVM.ProductName is not null)
        {
            products = products.Where(e => e.Name.Contains(productFilterVM.ProductName));
            ViewBag.ProductName = productFilterVM.ProductName;
        }

        // Pagination
        var totalNumberOfPage = Math.Ceiling(products.Count() / 8.0);

        if (page < 0)
            page = 1;

        products = products.Skip((page - 1) * 8).Take(count: 8);
        ViewBag.TotalNumberOfPage = totalNumberOfPage;
        ViewBag.CurrentPage = page;
        return View(products.ToList());
    }



    public IActionResult Details([FromRoute] int id)
    {
        var product = _context.Products.Include(e => e.Category).FirstOrDefault(e => e.ProductId == id);

        if (product is not null)
        {

            var TopProduct = _context.Products.Where(e => e.ProductId != product.ProductId).OrderByDescending(e => e.Traffic).Skip(0).Take(4);
            var productwithrelated = new ProductWithTopVM()
            {
                Product = product,

                TopProduct = TopProduct.ToList()
            };


            product.Traffic++;
            _context.SaveChanges();

            return View(productwithrelated);

        }
        return NotFound();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
