using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.Static;
using AGJProductInventory.Client.ViewModels;
using System.Net.Http.Json;

namespace AGJProductInventory.Client.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _http;
        private string _customerApiUrl;

        public CustomerService(HttpClient http)
        {
            _http = http;
            _customerApiUrl = APIEndpoints.s_customers;
        }

        public Task<CustomerViewModel> Create(CustomerViewModel customerDTO)
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

        public Task<CustomerViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return await _http.GetFromJsonAsync<IEnumerable<CustomerViewModel>>(_customerApiUrl);

            //var response = await _http.GetAsync(_customerApiUrl);
            //var content = await response.Content.ReadAsStringAsync();

            //if (response.IsSuccessStatusCode)
            //{
            //    var categories = JsonConvert.DeserializeObject<List<CustomerViewModel>>(content);
            //    return categories;
            //}
            //else
            //{
            //    var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
            //    throw new Exception(errorViewModel.ErrorMessage);
            //}
        }

        public Task<CustomerViewModel> Update(CustomerViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
