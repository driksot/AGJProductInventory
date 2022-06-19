using AGJProductInventory.Application.DTOs.Customer;
using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.Static;
using Newtonsoft.Json;
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

        public async Task<CustomerDTO> Create(CustomerDTO customerViewModel)
        {
            var response = await _http.PostAsJsonAsync<CustomerDTO>(_customerApiUrl, customerViewModel);
            return JsonConvert.DeserializeObject<CustomerDTO>(await response.Content.ReadAsStringAsync());
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            return await _http.GetFromJsonAsync<IEnumerable<CustomerDTO>>(_customerApiUrl);

            //var response = await _http.GetAsync(_customerApiUrl);
            //var content = await response.Content.ReadAsStringAsync();

            //if (response.IsSuccessStatusCode)
            //{
            //    var categories = JsonConvert.DeserializeObject<List<CustomerDTO>>(content);
            //    return categories;
            //}
            //else
            //{
            //    var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
            //    throw new Exception(errorViewModel.ErrorMessage);
            //}
        }

        public Task<CustomerDTO> Update(CustomerDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
