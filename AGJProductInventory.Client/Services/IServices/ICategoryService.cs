using AGJProductInventory.Application.DTOs.Category;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface ICategoryService
    {
        public Task<CategoryDTO> Get(int id);
        public Task<IEnumerable<CategoryDTO>> GetAll();
        public Task<CategoryDTO> Create(CategoryDTO categoryViewModel);
        public Task<CategoryDTO> Update(CategoryDTO categoryViewModel);
        public Task<int> Delete(int id);
        Task<bool> Exists(int id);
    }
}
