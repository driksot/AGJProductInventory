using AGJProductInventory.Application.Common;
using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Client.ViewModels
{
    public class ProductVariationViewModel
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }
    }
}
