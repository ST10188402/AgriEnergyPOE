using AgriEnergyPOE.Data;
using AgriEnergyPOE.Models;
using AgriEnergyPOE.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyPOE.Repositories
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly ApplicationDbContext _context;
        public FarmerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Farmer> CreateAsync(FarmerViewModel farmer)
        {
            var newFarmer = new Farmer
            {
                FarmName = farmer.FarmName,
                Specialty = farmer.Specialty,
                Name = farmer.Name,
                UserId = farmer.UserId
            };
            await _context.Farmers.AddAsync(newFarmer);
            await _context.SaveChangesAsync();
            return newFarmer;
        }

        public async Task<Farmer> DeleteAsync(int id)
        {
            Farmer farmer = await _context.Farmers.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
                await _context.SaveChangesAsync();
                
            }
            return farmer;

        }

        public async Task<List<FarmerViewModel>> GetAllAsync()
        {
            List<Farmer> farmers = await _context.Farmers.ToListAsync();
            List<FarmerViewModel> farmerViewModel = new List<FarmerViewModel>();
            foreach (var farmer in farmers)
            {
                farmerViewModel.Add(new FarmerViewModel
                {
                    FarmerId = farmer.Id,
                    FarmName = farmer.FarmName,
                    Specialty = farmer.Specialty,
                    Name = farmer.Name,
                    UserId = farmer.UserId
                });
            }
            return farmerViewModel;

        }

        public async Task<Farmer> GetByFarmName(string farmName)
        {
            await _context.Farmers.FirstOrDefaultAsync(x => x.FarmName == farmName);
            return  await _context.Farmers.FirstOrDefaultAsync(x => x.FarmName == farmName);

        }

        public async Task<Farmer> GetBySpecialty(string specialty)
        {
            await _context.Farmers.FirstOrDefaultAsync(x => x.Specialty == specialty);
            return await _context.Farmers.FirstOrDefaultAsync(x => x.Specialty == specialty);
        }
    }
}
