using AGJProductInventory.Application.DTOs;

namespace AGJProductInventory.Application.Contracts.Persistence
{
    public interface ICustomerRepository
    {
        public Task<CustomerDTO> Get(int id);
        public Task<IEnumerable<CustomerDTO>> GetAll();
        public Task<CustomerDTO> Create(CustomerDTO customerDTO);
        public Task<CustomerDTO> Update(CustomerDTO customerDTO);
        public Task<int> Delete(int id);
    }
}
