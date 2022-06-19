using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Application.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
    }
}
