using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class ProductVariationRepository : IProductVariationRepository
    {
        private readonly InventoryManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductVariationRepository(InventoryManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductVariationDTO> Get(int id)
        {
            var variation = await _dbContext.ProductVariations.FirstOrDefaultAsync(var => var.Id == id);

            if (variation != null)
            {
                return _mapper.Map<ProductVariation, ProductVariationDTO>(variation);
            }

            return new ProductVariationDTO();
        }

        public async Task<IEnumerable<ProductVariationDTO>> GetAll(int? id = null)
        {
            if (id != null && id > 0)
            {
                return _mapper.Map<IEnumerable<ProductVariation>, IEnumerable<ProductVariationDTO>>(_dbContext.ProductVariations.Where(var => var.ProductId == id));
            }
            else
            {
                return _mapper.Map<IEnumerable<ProductVariation>, IEnumerable<ProductVariationDTO>>(_dbContext.ProductVariations);
            }
        }

        public async Task<ProductVariationDTO> Create(ProductVariationDTO objDTO)
        {
            var variation = _mapper.Map<ProductVariationDTO, ProductVariation>(objDTO);

            var addedVariation = _dbContext.ProductVariations.Add(variation);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ProductVariation, ProductVariationDTO>(addedVariation.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var variation = await _dbContext.ProductVariations.FirstOrDefaultAsync(var => var.Id == id);

            if (variation != null)
            {
                _dbContext.ProductVariations.Remove(variation);
                await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<ProductVariationDTO> Update(ProductVariationDTO objDTO)
        {
            var variationFromDb = await _dbContext.ProductVariations.FirstOrDefaultAsync(var => var.Id == objDTO.Id);

            if (variationFromDb != null)
            {
                variationFromDb.Price = objDTO.Price;
                variationFromDb.Size = objDTO.Size;
                _dbContext.ProductVariations.Update(variationFromDb);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<ProductVariation, ProductVariationDTO>(variationFromDb);
            }

            return objDTO;
        }
    }
}
