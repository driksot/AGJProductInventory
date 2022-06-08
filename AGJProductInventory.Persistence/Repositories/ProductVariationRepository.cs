using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Domain;

namespace AGJProductInventory.Persistence.Repositories
{
    public class ProductVariationRepository : GenericRepository<ProductVariation>, IProductVariationRepository
    {
        private readonly InventoryManagementDbContext _dbContext;

        public ProductVariationRepository(InventoryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
