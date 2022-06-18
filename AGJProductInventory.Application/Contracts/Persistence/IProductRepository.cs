using AGJProductInventory.Application.DTOs;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task<ProductDTO> Get(int id);
        Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductDTO> Create(ProductDTO productDTO);
        public Task<ProductDTO> Update(ProductDTO productDTO);
        public Task<int> Archive(int id);
    }
}
