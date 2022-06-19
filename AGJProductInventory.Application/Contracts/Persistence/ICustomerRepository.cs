using AGJProductInventory.Application.DTOs.Customer;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface ICustomerRepository
    {
        public Task<CustomerDTO> Get(int id);
        public Task<IEnumerable<CustomerDTO>> GetAll();
        public Task<CreateCustomerDTO> Create(CreateCustomerDTO customerDTO);
        public Task<CustomerDTO> Update(CustomerDTO customerDTO);
        public Task<int> Delete(int id);
    }
}
