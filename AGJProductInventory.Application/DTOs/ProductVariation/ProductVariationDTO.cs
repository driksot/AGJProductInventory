using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Application.DTOs.ProductVariation
{
    public class ProductVariationDTO
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to {0}")]
        public double Price { get; set; }
    }
}
