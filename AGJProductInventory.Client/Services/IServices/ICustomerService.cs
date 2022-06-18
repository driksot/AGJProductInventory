using AGJProductInventory.Client.ViewModels;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface ICustomerService
    {
        public Task<CustomerViewModel> Get(int id);
        public Task<IEnumerable<CustomerViewModel>> GetAll();
        public Task<CustomerViewModel> Create(CustomerViewModel customerDTO);
        public Task<CustomerViewModel> Update(CustomerViewModel customerDTO);
        public Task<int> Delete(int id);
    }
}
