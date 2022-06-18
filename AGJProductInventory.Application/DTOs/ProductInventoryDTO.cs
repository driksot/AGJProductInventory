namespace AGJProductInventory.Application.DTOs
{
    public class ProductInventoryDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
