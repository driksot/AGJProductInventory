namespace AGJProductInventory.Domain
{
    public class ProductInventorySnapshot
    {
        public int Id { get; set; }
        public int ProductVariationId { get; set; }
        public ProductVariation ProductVariation { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime SnapshotTime { get; set; }

    }
}
