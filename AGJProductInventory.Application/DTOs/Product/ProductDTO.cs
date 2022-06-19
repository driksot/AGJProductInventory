using AGJProductInventory.Application.DTOs.Category;
using AGJProductInventory.Application.DTOs.ProductVariation;
using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Application.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }
        public CategoryDTO Category { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public ICollection<ProductVariationDTO> ProductVariations { get; set; }
    }
}
