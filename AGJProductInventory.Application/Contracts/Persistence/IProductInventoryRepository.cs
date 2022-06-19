using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Application.DTOs.ProductInventory;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface IProductInventoryRepository
    {
        public Task<IEnumerable<ProductInventoryDTO>> GetCurrentInventory();
        public Task<ProductInventoryDTO> UpdateUnitsAvailable(int id, int adjustment);
        public Task<ProductInventoryDTO> GetByProductId(int productId);
        public Task<IEnumerable<ProductInventorySnapshotDTO>> GetSnapshotHistory();

    }
}
