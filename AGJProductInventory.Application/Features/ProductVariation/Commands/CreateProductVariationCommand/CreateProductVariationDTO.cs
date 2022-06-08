using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.CreateProductVariationCommand
{
    public class CreateProductVariationDTO : IProductVariationDTO
    {
        public int ProductId { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
