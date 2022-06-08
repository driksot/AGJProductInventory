using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventorySnapshotQuery
{
    public class ProductInventorySnapshotListDTO : BaseDTO, IProductInventorySnapshotDTO
    {
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime SnapshotTime { get; set; }
    }
}
