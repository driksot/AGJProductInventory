using AGJProductInventory.Application.DTOs.Product;

namespace AGJProductInventory.Application.DTOs
{
    public class ProductInventorySnapshotDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime SnapshotTime { get; set; }
    }
}
