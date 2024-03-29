using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsAppPractice.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsAppPractice.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string searchString, string category)
    {

        var products = Repository.GetProducts;

        if(!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products.Where(p => p.Name.ToLower().Contains(searchString)).ToList();
        }
        if(!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }
        // ViewBag.Categories = new SelectList(Repository.GetCategories, "Id", "Name", category);

        var model = new ProductViewModel {
            Products = products,
            Categories = Repository.GetCategories,
            SelectedCategory = category
        };
        return View(model);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.GetCategories, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        Repository.AddProduct(product);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
