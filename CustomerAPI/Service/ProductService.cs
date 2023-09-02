using CustomerAPI.Models;
using CustomerAPI.Repository.Interface;
using CustomerAPI.Service.Interface;

namespace CustomerAPI.Service
{
    /// <summary>
    /// I haven't added all the functionalities. There is a Generic repository for adding/ Updating and Deleting the entities.
    /// And custom functions we need to specify in each repository.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            if(product.Id == Guid.Empty)
            {
                product.Id = Guid.NewGuid();
            }           

            return await _productRepository.Add(product);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAll();
        }
    }
}
