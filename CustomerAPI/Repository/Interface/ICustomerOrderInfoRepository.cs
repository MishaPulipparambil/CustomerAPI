using CustomerAPI.Models;

namespace CustomerAPI.Repository.Interface
{
    public interface ICustomerOrderInfoRepository : IGenericRepository<CustomerOrderInfo>
    {
        IEnumerable<CustomerOrderInfo> GetAllOrderForCustomer(Guid CustomerId);
    }
}
