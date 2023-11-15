using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics;
using TmsMvc.Models;

namespace TmsMvc.Controllers
{
    public class HomeController : Controller
    {
        private object syncRoot;
        private static List<ProductModel> products = new List<ProductModel>
        {
        };

        public static List<string> Catgories = new List<string>
        {
            "Smartpones",
            "TV",
            "Laptops",
        };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult List()
        {
            return View("List", products);
        }

        public IActionResult Add()
        {
            return View("Add");
        }

        public IActionResult Change()
        {

            return View("Change");
        }

        [HttpPost]
        public IActionResult Save([FromForm] ProductModel product)
        {
            product.Id = Guid.NewGuid();
            lock(syncRoot)
            {
                products.Add(product);
            }
            

            return RedirectToAction("list");
                //RedirectToRoute(new {action = "List",});
            // View("List", products);
        }

        [HttpPost]
        public IActionResult Delete([FromForm] ProductDeleteModel model)
        {
            lock (syncRoot) 
            {
                products.RemoveAll(x => x.Id == model.Id);
            }
            

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Change([FromForm] ProductModel model)
        { 
            ProductModel product = new ProductModel 
            {
                Id = new Guid(),
                Name = model.Name == null ? products.Where(x => x.Id == model.Id).First().Name : model.Name,
                Price = model.Price == 0 ? products.Where(x => x.Id == model.Id).First().Price : model.Price,
                Amount = model.Amount == 0 ? products.Where(x => x.Id == model.Id).First().Amount : model.Amount,
                Category = model.Category == null ? products.Where(x => x.Id == model.Id).First().Category : model.Category,
            };

            lock (syncRoot) 
            {
                products.Add(product);
            }

            //products.RemoveAll(x => x.Id == model.Id);
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}