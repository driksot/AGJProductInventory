using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AGJProductInventory.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InventoryManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(InventoryManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>
                (_dbContext.Customers.Include(cust => cust.CustomerAddress));
        }

        public async Task<CustomerDTO> Get(int id)
        {
            var customer = await _dbContext.Customers.Include(cust => cust.CustomerAddress)
                .FirstOrDefaultAsync(cust => cust.Id == id);
            if (customer != null)
            {
                return _mapper.Map<CustomerDTO>(customer);
            }
            return new CustomerDTO();
        }

        public async Task<CustomerDTO> Create(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);

            var addedCustomer = _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Customer, CustomerDTO>(addedCustomer.Entity);
        }

        public async Task<CustomerDTO> Update(CustomerDTO customerDTO)
        {
            var customerFromDb = await _dbContext.Customers.Include(cust => cust.CustomerAddress).FirstOrDefaultAsync(prod => prod.Id == customerDTO.Id);

            if (customerFromDb != null)
            {
                var addressFromDb = customerFromDb.CustomerAddress;
                customerFromDb.FirstName = customerDTO.FirstName;
                customerFromDb.LastName = customerDTO.FirstName;
                addressFromDb.AddressLine1 = customerDTO.CustomerAddress.AddressLine1;
                addressFromDb.AddressLine2 = customerDTO.CustomerAddress.AddressLine2;
                addressFromDb.City = customerDTO.CustomerAddress.City;
                addressFromDb.State = customerDTO.CustomerAddress.State;
                addressFromDb.PostalCode = customerDTO.CustomerAddress.PostalCode;
                addressFromDb.Country = customerDTO.CustomerAddress.Country;
                addressFromDb.PhoneNumber = customerDTO.CustomerAddress.PhoneNumber;
                customerFromDb.CustomerAddress = addressFromDb;
                _dbContext.Customers.Update(customerFromDb);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<Customer, CustomerDTO>(customerFromDb);
            }

            return customerDTO;
        }

        public async Task<int> Delete(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(cust => cust.Id == id);

            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }

            return 0;
        }
    }
}
