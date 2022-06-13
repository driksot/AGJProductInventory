namespace AGJProductInventory.Client.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerAddressViewModel CustomerAddress { get; set; }
        public int AddressId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
