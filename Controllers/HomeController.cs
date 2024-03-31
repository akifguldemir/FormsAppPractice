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
            products = products.Where(p => p.Name!.ToLower().Contains(searchString)).ToList();
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
    public async Task<IActionResult> Create(Product product, IFormFile imageFile)
    {
        var allowedExtensions = new[] {".jpg",".jpeg",".png"};
        var extension = Path.GetExtension(imageFile.FileName);
        var rndFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", rndFileName);

        if(imageFile != null && !allowedExtensions.Contains(extension))
        {
            ModelState.AddModelError("", "Geçerli bir resim seçiniz");
        }

        if(ModelState.IsValid) {
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile!.CopyToAsync(stream);
            }
            product.Image = rndFileName;
            product.Id = Repository.GetProducts.Count;
            Repository.AddProduct(product);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.GetCategories, "Id", "Name");
        return View(product);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
