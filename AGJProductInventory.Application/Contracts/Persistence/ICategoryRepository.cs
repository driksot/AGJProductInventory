using AGJProductInventory.Application.DTOs.Category;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface ICategoryRepository
    {
        public Task<CategoryDTO> Get(int id);
        public Task<IEnumerable<CategoryDTO>> GetAll();
        public Task<CreateCategoryDTO> Create(CreateCategoryDTO categoryDTO);
        public Task<CategoryDTO> Update(CategoryDTO categoryDTO);
        public Task<int> Delete(int id);
        Task<bool> Exists(int id);
    }
}
