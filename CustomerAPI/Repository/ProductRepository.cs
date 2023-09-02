using CustomerAPI.Models;
using CustomerAPI.Repository.Interface;

namespace CustomerAPI.Repository
{
    public class ProductRepository : GenericRepository<Product, AcmeCorpContext> , IProductRepository
    {
        public ProductRepository(AcmeCorpContext context) : base(context)
        {

        }
    }
}
