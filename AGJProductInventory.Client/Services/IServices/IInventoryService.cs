using AGJProductInventory.Application.DTOs.ProductInventory;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IInventoryService
    {
        Task<IEnumerable<ProductInventoryDTO>> GetCurrentInventory();
        Task<ProductInventoryDTO> UpdateUnitsAvailable(int id, int adjustment);
        Task<ProductInventoryDTO> GetByProductId(int productId);
        Task<IEnumerable<ProductInventoryDTO>> GetSnapshotHistory();
    }
}
