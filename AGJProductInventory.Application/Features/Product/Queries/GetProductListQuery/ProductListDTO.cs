using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoriesListQuery;
using AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationListQuery;

namespace AGJProductInventory.Application.Features.Product.Queries.GetProductListQuery
{
    public class ProductListDTO : BaseDTO, IProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }
        public int CategoryId { get; set; }
        public CategoryListDTO Category { get; set; }
        public ICollection<ProductVariationListDTO> ProductVariations { get; set; }
    }
}
