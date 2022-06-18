using AGJProductInventory.Client.ViewModels;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface ICategoryService
    {
        public Task<CategoryViewModel> Get(int id);
        public Task<IEnumerable<CategoryViewModel>> GetAll();
        public Task<CategoryViewModel> Create(CategoryViewModel categoryViewModel);
        public Task<CategoryViewModel> Update(CategoryViewModel categoryViewModel);
        public Task<int> Delete(int id);
        Task<bool> Exists(int id);
    }
}
