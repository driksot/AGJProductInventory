namespace AGJProductInventory.Application.Common
{
    public interface IProductInventorySnapshotDTO
    {
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime SnapshotTime { get; set; }
    }
}
