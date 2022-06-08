using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly InventoryManagementDbContext _dbContext;

        public CustomerRepository(InventoryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetCustomerWithDetails(int id)
        {
            var customer = await _dbContext.Customers.Include(q => q.CustomerAddress).FirstOrDefaultAsync(q => q.Id == id);
            return customer;
        }

        public async Task<List<Customer>> GetCustomerListWithDetails()
        {
            var customers = await _dbContext.Customers.Include(q => q.CustomerAddress).ToListAsync();
            return customers;
        }
    }
}
