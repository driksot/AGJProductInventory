using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Product.Queries.GetProductListQuery
{
    public class ProductListDTO : BaseDTO, IProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }
        public int CategoryId { get; set; }
    }
}
