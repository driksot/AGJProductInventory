namespace AGJProductInventory.Application.Common
{
    public interface IProductVariationDTO
    {
        public int ProductId { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
