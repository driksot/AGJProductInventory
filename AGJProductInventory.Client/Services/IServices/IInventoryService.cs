using AGJProductInventory.Client.ViewModels;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryViewModel>> GetCurrentInventory();
        Task<InventoryViewModel> UpdateUnitsAvailable(int id, int adjustment);
        Task<InventoryViewModel> GetByProductId(int productId);
        Task<IEnumerable<InventoryViewModel>> GetSnapshotHistory();
    }
}
