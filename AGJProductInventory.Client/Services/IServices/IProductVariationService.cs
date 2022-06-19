using AGJProductInventory.Application.DTOs.ProductVariation;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IProductVariationService
    {
        Task<ProductVariationDTO> Get(int id);
        Task<IEnumerable<ProductVariationDTO>> GetAll(int? id = null);
        Task<ProductVariationDTO> Create(ProductVariationDTO productVariationViewModel);
        Task<ProductVariationDTO> Update(ProductVariationDTO productVariationViewModel);
        Task<int> Delete(int id);
    }
}
