using AGJProductInventory.Client.Services.IServices;
using AGJProductInventory.Client.ViewModels;

namespace AGJProductInventory.Client.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        public Task<CustomerAddressViewModel> Add(CustomerAddressViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAddressViewModel> Delete(CustomerAddressViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAddressViewModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<CustomerAddressViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAddressViewModel> Update(CustomerAddressViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
