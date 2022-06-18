namespace AGJProductInventory.Client.ViewModels
{
    public class InventorySnapshotViewModel
    {
        public int Id { get; set; }
        public int ProductVariationId { get; set; }
        public ProductVariationViewModel ProductVariation { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime SnapshotTime { get; set; }
    }
}
