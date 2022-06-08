namespace AGJProductInventory.Application.Common
{
    public interface IProductInventoryDTO
    {
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
