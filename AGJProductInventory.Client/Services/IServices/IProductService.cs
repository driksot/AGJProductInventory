using AGJProductInventory.Application.DTOs.Product;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IProductService
    {
        Task<ProductDTO> Get(int id);
        Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductDTO> Create(ProductDTO productViewModel);
        public Task<ProductDTO> Update(ProductDTO productViewModel);
        public Task<int> Archive(int id);
    }
}
