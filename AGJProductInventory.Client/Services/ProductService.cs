using AGJProductInventory.Application.DTOs.Product;
using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.Static;
using AGJProductInventory.Client.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AGJProductInventory.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private string _productUrl;

        public ProductService(HttpClient http)
        {
            _http = http;
            _productUrl = APIEndpoints.s_products;
        }

        public Task<int> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> Create(ProductDTO productViewModel)
        {
            var response = await _http.PostAsJsonAsync<ProductDTO>(_productUrl, productViewModel);
            return JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());
        }

        public Task<ProductDTO> Delete(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> Get(int id)
        {
            return await _http.GetFromJsonAsync<ProductDTO>(_productUrl + "/" + id);

            //var response = await _http.GetAsync(_productUrl + "/" + id);
            //var content = await response.Content.ReadAsStringAsync();

            //if (response.IsSuccessStatusCode)
            //{
            //    var product = JsonConvert.DeserializeObject<ProductDTO>(content);
            //    //product.ImageUrl = APIEndpoints.ServerBaseUrl + "/wwwroot/" + product.ImageUrl;
            //    return product;
            //}
            //else
            //{
            //    var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
            //    throw new Exception(errorViewModel.ErrorMessage);
            //}
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var response = await _http.GetAsync(_productUrl);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(content);
                //foreach (var product in products)
                //{
                //    product.ImageUrl = APIEndpoints.ServerBaseUrl + "/wwwroot/" + product.ImageUrl;
                //}
                return products;
            }
            else
            {
                var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
                throw new Exception(errorViewModel.ErrorMessage);
            }
        }

        public async Task<ProductDTO> Update(ProductDTO productViewModel)
        {
            var result = await _http.PutAsJsonAsync($"{_productUrl}/{productViewModel.Id}", productViewModel);
            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ProductDTO>(response);
        }
    }
}
