using AGJProductInventory.Client.ViewModels;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface IProductService
    {
        Task<ProductViewModel> Get(int id);
        Task<IEnumerable<ProductViewModel>> GetAll();
        public Task<ProductViewModel> Create(ProductViewModel productViewModel);
        public Task<ProductViewModel> Update(ProductViewModel productViewModel);
        public Task<int> Archive(int id);
    }
}
