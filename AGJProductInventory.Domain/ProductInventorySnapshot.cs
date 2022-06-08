namespace AGJProductInventory.Domain
{
    public class ProductInventorySnapshot
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime SnapshotTime { get; set; }

    }
}
