using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoryDetailQuery;

namespace AGJProductInventory.Application.Features.Product.Queries.GetProductDetailQuery
{
    public class ProductDetailDTO : BaseDTO, IProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }
        public int CategoryId { get; set; }
    }
}
