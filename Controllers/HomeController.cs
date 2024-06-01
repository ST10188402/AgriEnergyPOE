using AgriEnergyPOE.Models;
using AgriEnergyPOE.Repositories;
using AgriEnergyPOE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgriEnergyPOE.Controllers
{
    [Authorize(Roles = "Farmer, Employee")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var productViewModels = products.Select(p => new ProductViewModel
            {
                ProductId = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category,
                DateAdded = p.DateAdded,
                FarmerId = p.FarmerId,
                Farmer = p.Farmer
            }).ToList();

            return View(productViewModels);
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
