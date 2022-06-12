using AGJProductInventory.Client.ViewModels;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IProductService : IGenericRepository<ProductViewModel>
    {
        Task<ProductViewModel> GetProductWithDetails(int id);
        Task<List<ProductViewModel>> GetProductListWithDetails();
    }
}
