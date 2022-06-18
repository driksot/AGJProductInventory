using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.Static;
using AGJProductInventory.Client.ViewModels;
using System.Net.Http.Json;

namespace AGJProductInventory.Client.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient _http;
        private string _inventoryApiUrl;

        public InventoryService(HttpClient http)
        {
            _http = http;
            _inventoryApiUrl = APIEndpoints.s_productInventories;
        }

        public async Task<IEnumerable<InventoryViewModel>> GetAll()
        {
            return await _http.GetFromJsonAsync<IReadOnlyList<InventoryViewModel>>(_inventoryApiUrl);
        }

        public Task<InventoryViewModel> GetByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InventoryViewModel>> GetCurrentInventory()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InventoryViewModel>> GetSnapshotHistory()
        {
            throw new NotImplementedException();
        }

        public Task<InventoryViewModel> UpdateUnitsAvailable(int id, int adjustment)
        {
            throw new NotImplementedException();
        }
    }
}
