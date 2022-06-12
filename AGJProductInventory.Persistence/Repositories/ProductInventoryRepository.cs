using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class ProductInventoryRepository : GenericRepository<ProductInventory>, IProductInventoryRepository
    {
        private readonly InventoryManagementDbContext _dbContext;

        public ProductInventoryRepository(InventoryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductInventory>> GetProductInventoryListWithDetails()
        {
            var inventoryList = await _dbContext.ProductInventories
                .Include(q => q.ProductVariation)
                .Where(q => !q.ProductVariation.Product.IsArchived)
                .ToListAsync();
            return inventoryList;
        }

        public async Task<List<ProductInventorySnapshot>> GetProductInventorySnapshots()
        {
            var start = DateTime.UtcNow - TimeSpan.FromDays(7);
            var snapshots = await _dbContext.ProductInventorySnapshots
                .Include(q => q.ProductVariation)
                .Where(q => q.SnapshotTime > start && !q.ProductVariation.Product.IsArchived)
                .ToListAsync();
            return snapshots;
        }

        public async Task<ProductInventory> GetProductInventoryWithDetails(int id)
        {
            var inventory = await _dbContext.ProductInventories
                .Include(q => q.ProductVariation)
                .FirstOrDefaultAsync(q => q.ProductVariationId == id);
            return inventory;
        }

        public async Task<ProductInventory> UpdateProductInventoryUnitsAvailable(int id, int adjustment)
        {
            var inventory = await _dbContext.ProductInventories
                .Include(q => q.ProductVariation)
                .FirstOrDefaultAsync(q => q.ProductVariationId == id);

            inventory.QuantityOnHand += adjustment;

            await CreateProductInventorySnapShot(inventory);

            await _dbContext.SaveChangesAsync();

            return inventory;
        }

        private async Task CreateProductInventorySnapShot(ProductInventory productInventory)
        {
            var snapshot = new ProductInventorySnapshot()
            {
                ProductVariation = productInventory.ProductVariation,
                QuantityOnHand = productInventory.QuantityOnHand,
                SnapshotTime = DateTime.UtcNow
            };

            await _dbContext.AddAsync(snapshot);
        }
    }
}
