using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public CategoryDTO Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductVariationDTO> ProductVariations { get; set; }
    }
}
