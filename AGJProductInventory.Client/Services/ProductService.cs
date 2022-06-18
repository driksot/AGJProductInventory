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

        public async Task<ProductViewModel> Create(ProductViewModel productViewModel)
        {
            var response = await _http.PostAsJsonAsync<ProductViewModel>(_productUrl, productViewModel);
            return JsonConvert.DeserializeObject<ProductViewModel>(await response.Content.ReadAsStringAsync());
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
            return await _http.GetFromJsonAsync<ProductViewModel>(_productUrl + "/" + id);

            //var response = await _http.GetAsync(_productUrl + "/" + id);
            //var content = await response.Content.ReadAsStringAsync();

            //if (response.IsSuccessStatusCode)
            //{
            //    var product = JsonConvert.DeserializeObject<ProductViewModel>(content);
            //    //product.ImageUrl = APIEndpoints.ServerBaseUrl + "/wwwroot/" + product.ImageUrl;
            //    return product;
            //}
            //else
            //{
            //    var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
            //    throw new Exception(errorViewModel.ErrorMessage);
            //}
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var response = await _http.GetAsync(_productUrl);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductViewModel>>(content);
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

        public async Task<ProductViewModel> Update(ProductViewModel productViewModel)
        {
            var result = await _http.PutAsJsonAsync($"{_productUrl}/{productViewModel.Id}", productViewModel);
            var response = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ProductViewModel>(response);
        }
    }
}
