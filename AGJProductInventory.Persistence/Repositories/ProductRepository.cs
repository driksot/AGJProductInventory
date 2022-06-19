using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.Product;
using AGJProductInventory.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(InventoryManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>
                (_dbContext.Products.Include(prod => prod.Category).Include(prod => prod.ProductVariations));
        }

        public async Task<ProductDTO> Get(int id)
        {
            var product = await _dbContext.Products.Include(prod => prod.Category).Include(prod => prod.ProductVariations)
                .FirstOrDefaultAsync(prod => prod.Id == id);
            if (product != null)
            {
                return _mapper.Map<ProductDTO>(product);
            }
            return new ProductDTO();
        }

        public async Task<CreateProductDTO> Create(CreateProductDTO productDTO)
        {
            var product = _mapper.Map<CreateProductDTO, Product>(productDTO);

            var addedProduct = _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Product, CreateProductDTO>(addedProduct.Entity);
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
            var productFromDb = await _dbContext.Products.FirstOrDefaultAsync(prod => prod.Id == productDTO.Id);

            if (productFromDb != null)
            {
                productFromDb.Name = productDTO.Name;
                productFromDb.Description = productDTO.Description;
                productFromDb.ImageUrl = productDTO.ImageUrl;
                productFromDb.CategoryId = productDTO.CategoryId;
                _dbContext.Products.Update(productFromDb);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<Product, ProductDTO>(productFromDb);
            }

            return productDTO;
        }

        public async Task<int> Archive(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            product.IsArchived = true;
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }
    }
}
