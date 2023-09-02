using CustomerAPI.Models;
using CustomerAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repository
{
    public class CustomerOrderInfoRepository : GenericRepository<CustomerOrderInfo, AcmeCorpContext>, ICustomerOrderInfoRepository
    {
        private readonly AcmeCorpContext _context;
        public CustomerOrderInfoRepository(AcmeCorpContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<CustomerOrderInfo> GetAllOrderForCustomer(Guid CustomerId)
        {
            return _context.CustomerOrderInfos.Include(d=>d.Customer).Include(p=>p.Product).Where(c => c.CustomerId == CustomerId).ToList();
        }

    }
}
