using CustomerAPI.Models;
using CustomerAPI.Repository.Interface;

namespace CustomerAPI.Repository
{
    public class AddressInfoRepository : GenericRepository<AddressInfo, AcmeCorpContext>, IAddressInfoRepository
    {
        public AddressInfoRepository(AcmeCorpContext context) : base(context)
        {

        }
    }
}
