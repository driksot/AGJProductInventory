using AGJProductInventory.Application.DTOs;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface IProductVariationRepository
    {
        public Task<ProductVariationDTO> Get(int id);
        public Task<IEnumerable<ProductVariationDTO>> GetAll(int? id = null);
        public Task<ProductVariationDTO> Create(ProductVariationDTO productVariationDTO);
        public Task<ProductVariationDTO> Update(ProductVariationDTO productVariationDTO);
        public Task<int> Delete(int id);
    }
}
