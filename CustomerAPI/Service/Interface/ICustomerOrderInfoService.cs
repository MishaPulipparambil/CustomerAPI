using CustomerAPI.DTO;
using CustomerAPI.Models;

namespace CustomerAPI.Service.Interface
{
    public interface ICustomerOrderInfoService
    {
        public Task<CustomerOrderInfo> CreateCustomerOrder(CustomerOrderDto customerOrderInfo);
        public IEnumerable<CustomerOrderDto> GetAllOrderForCustomer(Guid customerId);
    }
}
