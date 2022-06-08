using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Domain;

namespace AGJProductInventory.Persistence.Repositories
{
    public class CustomerAddressRepository : GenericRepository<CustomerAddress>, ICustomerAddressRepository
    {
        private readonly InventoryManagementDbContext _dbContext;

        public CustomerAddressRepository(InventoryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
