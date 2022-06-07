using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductDTO : IProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
