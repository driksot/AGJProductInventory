using AGJProductInventory.Application.Common;
using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Client.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name...")]
        public string Name { get; set; }
    }
}
