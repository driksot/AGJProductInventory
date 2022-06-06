namespace AGJProductInventory.Application.Common
{
    public class IProductInventoryDTO
    {
        public IProductDTO ProductDTO { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
