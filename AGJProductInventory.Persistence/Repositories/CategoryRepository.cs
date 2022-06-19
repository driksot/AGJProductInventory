using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.Category;
using AGJProductInventory.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InventoryManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(InventoryManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(cat => cat.Id == id);

            if (category != null)
            {
                return _mapper.Map<Category, CategoryDTO>(category);
            }

            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_dbContext.Categories);
        }

        public async Task<CreateCategoryDTO> Create(CreateCategoryDTO categoryDTO)
        {
            var category = _mapper.Map<CreateCategoryDTO, Category>(categoryDTO);

            var addedCategory = _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Category, CreateCategoryDTO>(addedCategory.Entity);
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var categoryFromDb = await _dbContext.Categories.FirstOrDefaultAsync(cat => cat.Id == categoryDTO.Id);

            if (categoryFromDb != null)
            {
                categoryFromDb.Name = categoryDTO.Name;
                _dbContext.Categories.Update(categoryFromDb);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<Category, CategoryDTO>(categoryFromDb);
            }

            return categoryDTO;
        }

        public async Task<int> Delete(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(cat => cat.Id == id);

            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }
    }
}
