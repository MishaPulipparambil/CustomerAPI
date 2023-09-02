using CustomerAPI.Models;
using CustomerAPI.Repository.Interface;

namespace CustomerAPI.Repository;

public class CustomerRepository : GenericRepository<Customer,AcmeCorpContext> , ICustomerRepository
{
    public CustomerRepository(AcmeCorpContext context) : base(context)
    {

    }
}