using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TmsMvc.Models;

namespace TmsMvc.Controllers
{
    public class HomeController : Controller
    {
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
            products.Add(product);

            return View("List", products);
        }

        [HttpPost]
        public IActionResult Delete([FromForm] ProductDeleteModel model)
        {
            products.RemoveAll(x => x.Id == model.Id);

            return View("List", products);
        }

        [HttpPost]
        public IActionResult Change([FromForm] ProductModel model)
        { 
            return View("List", products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}