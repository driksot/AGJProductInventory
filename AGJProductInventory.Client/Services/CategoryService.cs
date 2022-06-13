using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.Static;
using AGJProductInventory.Client.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AGJProductInventory.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        private string _categoryUrl;

        public CategoryService(HttpClient http)
        {
            _http = http;
            _categoryUrl = APIEndpoints.s_categories;
        }

        public async Task<CategoryViewModel> Add(CategoryViewModel entity)
        {
            try
            {
                using var request = new HttpRequestMessage();
                var content = new StringContent(JsonConvert.SerializeObject(entity));
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                request.Content = content;
                request.Method = HttpMethod.Post;
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                var result = await _http.PostAsync(_categoryUrl, request.Content);
                var response = await result.Content.ReadAsStringAsync();

                var category = JsonConvert.DeserializeObject<CategoryViewModel>(response);

                if (category == null) throw new Exception(); // TODO: create null exception
                    
                return category;
            }
            catch (Exception ex)
            {
                return entity;
            }
        }

        public async Task<CategoryViewModel> Delete(CategoryViewModel entity)
        {
            var categoryId = entity.Id;
            var response = await _http.GetAsync(_categoryUrl + categoryId);
            var content = await response.Content.ReadAsStringAsync();

            await _http.DeleteAsync(_categoryUrl + categoryId);

            var category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
            return category;
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryViewModel> Get(int id)
        {
            var response = await _http.GetAsync(_categoryUrl + id);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var category = JsonConvert.DeserializeObject<CategoryViewModel>(content);
                return category;
            }
            else
            {
                var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
                throw new Exception(errorViewModel.ErrorMessage);
            }
        }

        public async Task<IReadOnlyList<CategoryViewModel>> GetAll()
        {
            var response = await _http.GetAsync(_categoryUrl);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
                return categories;
            }
            else
            {
                var errorViewModel = JsonConvert.DeserializeObject<ErrorViewModel>(content);
                throw new Exception(errorViewModel.ErrorMessage);
            }
        }

        public async Task<CategoryViewModel> Update(CategoryViewModel entity)
        {
            var categoryId = entity.Id;

            try
            {
                using var request = new HttpRequestMessage();
                var content = new StringContent(JsonConvert.SerializeObject(entity));
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                request.Content = content;
                request.Method = HttpMethod.Post;
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                var result = await _http.PutAsync(_categoryUrl + categoryId, request.Content);
                var response = await result.Content.ReadAsStringAsync();

                var category = JsonConvert.DeserializeObject<CategoryViewModel>(response);

                if (category == null) throw new Exception(); // TODO: create null exception

                return category;
            }
            catch (Exception ex)
            {
                return entity;
            }
        }
    }
}
