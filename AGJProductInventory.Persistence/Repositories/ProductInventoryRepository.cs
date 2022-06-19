using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Application.DTOs.ProductInventory;
using AGJProductInventory.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class ProductInventoryRepository : IProductInventoryRepository
    {
        private readonly InventoryManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductInventoryRepository(InventoryManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductInventoryDTO> GetByProductId(int productId)
        {
            var inventory = await _dbContext.ProductInventories
                .Include(inv => inv.Product)
                .Include(inv => inv.Product.Category)
                .Include(inv => inv.Product.ProductVariations)
                .FirstOrDefaultAsync(inv => inv.ProductId == productId);
            return _mapper.Map<ProductInventoryDTO>(inventory);
        }

        public async Task<IEnumerable<ProductInventoryDTO>> GetCurrentInventory()
        {
            var inventoryList = await _dbContext.ProductInventories
                .Include(inv => inv.Product)
                .Include(inv => inv.Product.Category)
                .Include(inv => inv.Product.ProductVariations)
                .Where(inv => !inv.Product.IsArchived)
                .ToListAsync();
            return _mapper.Map<IEnumerable<ProductInventoryDTO>>(inventoryList);
        }

        public Task<IEnumerable<ProductInventorySnapshotDTO>> GetSnapshotHistory()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductInventoryDTO> UpdateUnitsAvailable(int id, int adjustment)
        {
            var inventory = await _dbContext.ProductInventories
                .Include(inv => inv.Product)
                .Include(inv => inv.Product.Category)
                .Include(inv => inv.Product.ProductVariations)
                .FirstOrDefaultAsync(inv => inv.ProductId == id);

            inventory.QuantityOnHand += adjustment;

            await CreateProductInventorySnapShot();

            await _dbContext.SaveChangesAsync();

            var inventoryDTO = _mapper.Map<ProductInventoryDTO>(inventory);

            return inventoryDTO;
        }

        private async Task CreateProductInventorySnapShot()
        {
            var inventories = await _dbContext.ProductInventories
                .Include(inv => inv.Product)
                .Include(inv => inv.Product.Category)
                .Include(inv => inv.Product.ProductVariations)
                .ToListAsync();

            foreach (var inventory in inventories)
            {
                var snapshot = new ProductInventorySnapshot
                {
                    Product = inventory.Product,
                    QuantityOnHand = inventory.QuantityOnHand,
                    SnapshotTime = DateTime.UtcNow
                };

                await _dbContext.AddAsync(snapshot);
            }  
        }
    }
}
