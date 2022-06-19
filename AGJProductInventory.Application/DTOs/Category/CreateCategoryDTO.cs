using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Application.DTOs.Category
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Please enter name...")]
        public string Name { get; set; }
    }
}
