using AGJProductInventory.Client.ViewModels;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IProductVariationService : IGenericRepository<ProductVariationViewModel>
    {
        Task<List<ProductVariationViewModel>> GetAllByProduct(int productId);
    }
}
