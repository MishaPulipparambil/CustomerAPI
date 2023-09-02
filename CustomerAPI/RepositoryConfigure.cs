using Azure;
using CustomerAPI.Repository;
using CustomerAPI.Repository.Interface;
using CustomerAPI.Service;
using CustomerAPI.Service.Interface;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CustomerAPI
{
    public static class RepositoryConfigure
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressInfoRepository, AddressInfoRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerOrderInfoRepository, CustomerOrderInfoRepository>();



            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerOrderInfoService, CustomerOrderInfoService>();
           
        }
    }

 
}
