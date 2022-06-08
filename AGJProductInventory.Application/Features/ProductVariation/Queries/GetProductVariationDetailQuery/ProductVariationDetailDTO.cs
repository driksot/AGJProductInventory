using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationDetailQuery
{
    public class ProductVariationDetailDTO : BaseDTO, IProductVariationDTO
    {
        public int ProductId { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
