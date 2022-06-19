using AGJProductInventory.Application.DTOs.ProductVariation;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface IProductVariationRepository
    {
        public Task<ProductVariationDTO> Get(int id);
        public Task<IEnumerable<ProductVariationDTO>> GetAll(int? id = null);
        public Task<CreateProductVariationDTO> Create(CreateProductVariationDTO productVariationDTO);
        public Task<ProductVariationDTO> Update(ProductVariationDTO productVariationDTO);
        public Task<int> Delete(int id);
    }
}
