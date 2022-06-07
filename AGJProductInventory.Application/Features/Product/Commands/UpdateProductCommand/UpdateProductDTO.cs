using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductDTO : IProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
