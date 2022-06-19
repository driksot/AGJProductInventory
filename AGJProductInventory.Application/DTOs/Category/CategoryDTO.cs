using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Application.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name...")]
        public string Name { get; set; }
    }
}
