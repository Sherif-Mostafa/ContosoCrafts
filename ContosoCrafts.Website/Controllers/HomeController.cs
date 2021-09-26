using ContosoCrafts.Website.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public JsonFileProductService _productService;
        public IEnumerable<Product> products { get; private set; }
        public HomeController(ILogger<HomeController> logger, JsonFileProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            products = _productService.GetProducts();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
