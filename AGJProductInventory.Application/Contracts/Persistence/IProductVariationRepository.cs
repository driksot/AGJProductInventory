using AGJProductInventory.Domain;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface IProductVariationRepository : IGenericRepository<ProductVariation>
    {
        Task<List<ProductVariation>> GetAllByProduct(int productId);
    }
}
