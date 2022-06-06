namespace AGJProductInventory.Application.Common
{
    public interface IProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }
        public ICategoryDTO CategoryDTO { get; set; }
    }
}
