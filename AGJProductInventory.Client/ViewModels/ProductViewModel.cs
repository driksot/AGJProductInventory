using AGJProductInventory.Application.Common;
using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Client.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
