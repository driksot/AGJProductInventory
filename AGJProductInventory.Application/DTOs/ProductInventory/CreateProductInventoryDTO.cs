namespace AGJProductInventory.Application.DTOs.ProductInventory
{
    public class CreateProductInventoryDTO
    {
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
