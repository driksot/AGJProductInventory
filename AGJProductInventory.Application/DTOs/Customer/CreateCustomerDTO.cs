using System.ComponentModel.DataAnnotations;

namespace AGJProductInventory.Application.DTOs.Customer
{
    public class CreateCustomerDTO
    {
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }
        public CreateCustomerAddressDTO CustomerAddress { get; set; }
    }

    public class CreateCustomerAddressDTO
    {
        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(2)]
        public string State { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(32)]
        public string Country { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
