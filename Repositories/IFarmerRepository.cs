using AgriEnergyPOE.Models;
using AgriEnergyPOE.ViewModels;

namespace AgriEnergyPOE.Repositories
{
    public interface IFarmerRepository
    {
        Task<List<FarmerViewModel>> GetAllAsync();
        Task<Farmer> CreateAsync(FarmerViewModel farmer);
        Task<Farmer> GetBySpecialty(string specialty);
        Task<Farmer> GetByFarmName(string farmName);
        Task<Farmer> DeleteAsync(int id);
    }
}
