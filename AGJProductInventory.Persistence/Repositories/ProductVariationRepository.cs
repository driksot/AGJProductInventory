using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class ProductVariationRepository : GenericRepository<ProductVariation>, IProductVariationRepository
    {
        private readonly InventoryManagementDbContext _dbContext;

        public ProductVariationRepository(InventoryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductVariation>> GetAllByProduct(int productId)
        {
            var variations = await _dbContext.ProductVariations.Where(q => q.ProductId == productId).ToListAsync();
            return variations;
        }
    }
}
