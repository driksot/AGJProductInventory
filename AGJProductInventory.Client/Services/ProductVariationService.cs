﻿using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.ViewModels;
using Newtonsoft.Json;

namespace AGJProductInventory.Client.Services
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly HttpClient _http;
        private string VariationUrl;

        public ProductVariationService(HttpClient http)
        {
            _http = http;
            VariationUrl = "/api/productvariations/";
        }

        public Task<ProductVariationViewModel> Add(ProductVariationViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductVariationViewModel> Delete(ProductVariationViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductVariationViewModel> Get(int id)
        {
            var response = await _http.GetAsync(VariationUrl + id);
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

        public Task<IReadOnlyList<ProductVariationViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductVariationViewModel>> GetAllByProduct(int productId)
        {
            var response = await _http.GetAsync(VariationUrl + $"product/{productId}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var variations = JsonConvert.DeserializeObject<List<ProductVariationViewModel>>(content);
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
