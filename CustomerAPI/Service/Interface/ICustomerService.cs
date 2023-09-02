using CustomerAPI.Models;

namespace CustomerAPI.Service.Interface
{
    public interface ICustomerService
    {
        public Task<Customer> AddCustomer(CustomerDto customer);
        public Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
