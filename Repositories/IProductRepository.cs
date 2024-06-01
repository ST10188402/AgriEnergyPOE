using AgriEnergyPOE.Models;
using AgriEnergyPOE.ViewModels;

namespace AgriEnergyPOE.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Farmer>> GetAllFarmers();
        Task<Product> CreateAsync(ProductViewModel product);
        Task<Product> GetByCategory(string category);
        Task<List<Product>> GetByFarmerID(int farmerID);
        Task<List<int>> GetAllFarmerID();
        Task<int> GetFarmerIdByUserId(string userId);
    }
}
