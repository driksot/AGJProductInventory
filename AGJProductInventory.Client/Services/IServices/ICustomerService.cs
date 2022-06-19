using AGJProductInventory.Application.DTOs.Customer;

namespace AGJProductInventory.Client.Services.IServices
{
    public interface ICustomerService
    {
        public Task<CustomerDTO> Get(int id);
        public Task<IEnumerable<CustomerDTO>> GetAll();
        public Task<CustomerDTO> Create(CustomerDTO customerDTO);
        public Task<CustomerDTO> Update(CustomerDTO customerDTO);
        public Task<int> Delete(int id);
    }
}
