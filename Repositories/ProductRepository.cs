using AgriEnergyPOE.Data;
using AgriEnergyPOE.Models;
using AgriEnergyPOE.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyPOE.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task<Product> CreateAsync(ProductViewModel product)
        {
            var newProduct = new Product
            {
                Title = product.Title,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
                FarmerId = product.FarmerId,
                DateAdded = DateTime.Now
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<int> GetFarmerIdByUserId(string userId)
        {
            return await _context.Farmers
                .Where(f => f.UserId == userId)
                .Select(f => f.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Farmer).ToListAsync();
        }

        public async Task<List<Farmer>> GetAllFarmers()
        {
            return await _context.Farmers.ToListAsync();
        }

        public async Task<List<int>> GetAllFarmerID()
        {
            return await _context.Farmers.Select(f => f.Id).ToListAsync();
        }
        public async Task<Product> GetByCategory(string category)
        {
            await _context.Products.FirstOrDefaultAsync(x => x.Category == category);
            return await _context.Products.FirstOrDefaultAsync(x => x.Category == category);
        }

        public async Task<List<Product>> GetByFarmerID(int farmerId)
        {
            return await _context.Products
                .Where(p => p.FarmerId == farmerId)
                .Include(p => p.Farmer)
                .ToListAsync();
        }
    }
}
