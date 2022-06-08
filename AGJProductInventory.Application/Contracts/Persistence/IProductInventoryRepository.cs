using AGJProductInventory.Domain;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface IProductInventoryRepository : IGenericRepository<ProductInventory>
    {
        Task<List<ProductInventory>> GetProductInventoryListWithDetails();
        Task<ProductInventory> GetProductInventoryWithDetails(int id);
        Task<ProductInventory> UpdateProductInventoryUnitsAvailable(int id, int adjustment);
        Task<List<ProductInventorySnapshot>> GetProductInventorySnapshots();

    }
}
