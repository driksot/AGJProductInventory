using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly InventoryManagementDbContext _dbContext;

        public ProductRepository(InventoryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductListWithDetails()
        {
            var products = await _dbContext.Products.Include(q => q.Category).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductWithDetails(int id)
        {
            var product = await _dbContext.Products.Include(q => q.Category).FirstOrDefaultAsync(q => q.Id == id);
            return product;
        }

        public async Task Archive(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            product.IsArchived = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}
