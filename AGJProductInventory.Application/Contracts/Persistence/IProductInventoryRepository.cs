using AGJProductInventory.Application.DTOs;

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
