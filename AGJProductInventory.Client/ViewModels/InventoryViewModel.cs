namespace AGJProductInventory.Client.ViewModels
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public ProductVariationViewModel ProductVariation { get; set; }
        public int ProductVariationId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
