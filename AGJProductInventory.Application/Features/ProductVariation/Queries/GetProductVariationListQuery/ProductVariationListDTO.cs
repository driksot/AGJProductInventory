using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Product.Queries.GetProductListQuery;

namespace AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationListQuery
{
    public class ProductVariationListDTO : BaseDTO, IProductVariationDTO
    {
        public int ProductId { get; set; }
        public ProductListDTO Product { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
