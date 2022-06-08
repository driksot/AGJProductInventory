using AGJProductInventory.Domain;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerWithDetails(int id);
        Task<List<Customer>> GetCustomerListWithDetails();
    }
}
