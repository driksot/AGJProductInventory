using AGJProductInventory.Client.ViewModels;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IProductVariationService
    {
        Task<ProductVariationViewModel> Get(int id);
        Task<IEnumerable<ProductVariationViewModel>> GetAll(int? id = null);
        Task<ProductVariationViewModel> Create(ProductVariationViewModel productVariationViewModel);
        Task<ProductVariationViewModel> Update(ProductVariationViewModel productVariationViewModel);
        Task<int> Delete(int id);
    }
}
