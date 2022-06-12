using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryListQuery
{
    public class ProductInventoryListDTO : BaseDTO, IProductInventoryDTO
    {
        public int ProductVariationId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
