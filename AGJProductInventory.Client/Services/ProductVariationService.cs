using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.Static;
using AGJProductInventory.Client.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AGJProductInventory.Client.Services
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly HttpClient _http;
        private string _variationUrl;

        public ProductVariationService(HttpClient http)
        {
            _http = http;
            _variationUrl = APIEndpoints.s_productVariations;
        }

        public async Task<ProductVariationViewModel> Create(ProductVariationViewModel productVariationViewModel)
        {
            var result = await _http.PostAsJsonAsync(_variationUrl, productVariationViewModel);
            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ProductVariationViewModel>(response);
        }

        public Task<ProductVariationViewModel> Delete(ProductVariationViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductVariationViewModel> Get(int id)
        {
            var response = await _http.GetAsync(_variationUrl + "/" + id);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var variation = JsonConvert.DeserializeObject<ProductVariationViewModel>(content);
                return variation;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<ProductVariationViewModel>> GetAll(int? id = null)
        {
            var response = await _http.GetAsync(_variationUrl + $"/product/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var variations = JsonConvert.DeserializeObject<IEnumerable<ProductVariationViewModel>>(content);
                return variations;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public Task<ProductVariationViewModel> Update(ProductVariationViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
