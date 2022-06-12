using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.ViewModels;
using Newtonsoft.Json;

namespace AGJProductInventory.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;
        private string ProductImageUrl;
        private string ProductUrl;

        public ProductService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
            ProductImageUrl = _configuration.GetSection("ProductImageUrl").Value;
            ProductUrl = "/api/products/";
        }

        public Task<ProductViewModel> Add(ProductViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> Delete(ProductViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductViewModel> Get(int id)
        {
            var response = await _http.GetAsync(ProductUrl + id);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var product = JsonConvert.DeserializeObject<ProductViewModel>(content);
                product.ImageUrl = ProductImageUrl + product.ImageUrl;
                return product;
            }
            else
            {
                var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
                throw new Exception(errorViewModel.ErrorMessage);
            }
        }

        public Task<IReadOnlyList<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetProductListWithDetails()
        {
            var response = await _http.GetAsync(ProductUrl);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var products = JsonConvert.DeserializeObject<List<ProductViewModel>>(content);
                foreach (var product in products)
                {
                    product.ImageUrl = ProductImageUrl + product.ImageUrl;
                }
                return products;
            }
            else
            {
                var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
                throw new Exception(errorViewModel.ErrorMessage);
            }
        }

        public Task<ProductViewModel> GetProductWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> Update(ProductViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
