using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.UpdateProductVariationCommand
{
    public class UpdateProductVariationDTO : IProductVariationDTO
    {
        public int ProductId { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
