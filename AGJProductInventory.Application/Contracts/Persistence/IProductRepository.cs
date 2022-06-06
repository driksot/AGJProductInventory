using AGJProductInventory.Domain;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductWithDetails(int id);
        Task<List<Product>> GetProductListWithDetails();
    }
}
