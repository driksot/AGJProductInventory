using AGJProductInventory.Application.DTOs.Product;

namespace AGJProductInventory.Application.DTOs.ProductInventory
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
