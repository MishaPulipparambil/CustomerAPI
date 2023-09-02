using CustomerAPI.Models;

namespace CustomerAPI.Service.Interface
{
    public interface IProductService
    {
        public Task<Product> AddProduct(Product product);
        public Task<IEnumerable<Product>> GetProductsAsync();
    }
}
