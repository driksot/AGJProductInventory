namespace AGJProductInventory.Application.DTOs
{
    public class ProductInventoryUpdateDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
        public int Adjustment { get; set; }
    }
}
