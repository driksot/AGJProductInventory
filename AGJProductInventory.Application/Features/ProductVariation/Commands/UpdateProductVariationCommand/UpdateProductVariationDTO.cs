using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Product.Queries.GetProductDetailQuery;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.UpdateProductVariationCommand
{
    public class UpdateProductVariationDTO : IProductVariationDTO
    {
        public int ProductId { get; set; }
        public ProductDetailDTO Product { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
