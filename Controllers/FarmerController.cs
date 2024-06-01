using AgriEnergyPOE.Repositories;
using AgriEnergyPOE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyPOE.Controllers
{
    [Authorize(Roles = "Employee")]
    public class FarmerController : Controller
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public FarmerController(IFarmerRepository farmerRepository, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _farmerRepository = farmerRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var farmers = await _farmerRepository.GetAllAsync();
            var farmerViewModel = farmers.Select(f => new FarmerViewModel
            {
                FarmerId = f.FarmerId,
                FarmName = f.FarmName,
                Specialty = f.Specialty,
                Name = f.Name
            }).ToList();
            return View(farmerViewModel);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Add(FarmerViewModel farmerViewModel)
        {
            var user = new IdentityUser { UserName = farmerViewModel.Email, Email = farmerViewModel.Email };
            var result = await _userManager.CreateAsync(user, farmerViewModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Farmer");
                farmerViewModel.UserId = user.Id;

                await _farmerRepository.CreateAsync(farmerViewModel);
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(farmerViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _farmerRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
