using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Domain;

namespace AGJProductInventory.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly InventoryManagementDbContext _dbContext;

        public CategoryRepository(InventoryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
