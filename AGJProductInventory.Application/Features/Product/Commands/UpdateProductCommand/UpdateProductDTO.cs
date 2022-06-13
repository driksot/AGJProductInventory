using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoryDetailQuery;
using AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationListQuery;

namespace AGJProductInventory.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductDTO : IProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryDetailDTO Category { get; set; }
        public ICollection<ProductVariationListDTO> ProductVariations { get; set; }
    }
}
