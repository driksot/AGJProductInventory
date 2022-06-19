using AGJProductInventory.Application.DTOs.ProductInventory;
using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.Static;
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

        public async Task<IEnumerable<ProductInventoryDTO>> GetAll()
        {
            return await _http.GetFromJsonAsync<IReadOnlyList<ProductInventoryDTO>>(_inventoryApiUrl);
        }

        public Task<ProductInventoryDTO> GetByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductInventoryDTO>> GetCurrentInventory()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductInventoryDTO>> GetSnapshotHistory()
        {
            throw new NotImplementedException();
        }

        public Task<ProductInventoryDTO> UpdateUnitsAvailable(int id, int adjustment)
        {
            throw new NotImplementedException();
        }
    }
}
