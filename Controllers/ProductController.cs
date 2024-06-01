using AgriEnergyPOE.Repositories;
using AgriEnergyPOE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgriEnergyPOE.Controllers
{
    [Authorize(Roles = "Farmer, Employee")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductController(IProductRepository productRepository, UserManager<IdentityUser> userManager)
        {
            _productRepository = productRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string searchString, string category, DateTime? startDate, DateTime? endDate)
        {
            var products = await _productRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                products = products.Where(p => p.Farmer.Name.ToLower().Contains(searchString)).ToList();
            }
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category).ToList();
            }
            if (startDate.HasValue)
            {
                products = products.Where(p => p.DateAdded >= startDate.Value).ToList();
            }
            if (endDate.HasValue)
            {
                products = products.Where(p => p.DateAdded <= endDate.Value).ToList();
            }

            var productViewModels = products.Select(p => new ProductViewModel
            {
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category,
                DateAdded = p.DateAdded,
                Farmer = p.Farmer,
            }).ToList();

            return View(productViewModels);
        }
        [Authorize(Roles = "Farmer")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Index");
            }

            var farmerId = await _productRepository.GetFarmerIdByUserId(userId);

            productViewModel.FarmerId = farmerId;

            await _productRepository.CreateAsync(productViewModel);
            return RedirectToAction("Index");
        }
    }
}
