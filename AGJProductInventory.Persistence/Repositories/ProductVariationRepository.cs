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

        public async Task<ProductVariation> CreateProductVariationAndInventory(ProductVariation productVariation)
        {
            try
            {
                await _dbContext.ProductVariations.AddAsync(productVariation);

                var newInventory = new ProductInventory
                {
                    ProductVariation = productVariation,
                    QuantityOnHand = 0,
                    IdealQuantity = 10
                };

                await _dbContext.ProductInventories.AddAsync(newInventory);
                await _dbContext.SaveChangesAsync();

                return productVariation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductVariation>> GetAllByProduct(int productId)
        {
            var variations = await _dbContext.ProductVariations.Where(q => q.ProductId == productId).ToListAsync();
            return variations;
        }
    }
}
