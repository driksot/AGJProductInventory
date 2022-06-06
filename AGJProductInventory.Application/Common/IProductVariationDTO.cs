namespace AGJProductInventory.Application.Common
{
    public interface IProductVariationDTO
    {
        public IProductDTO ProductDTO { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
