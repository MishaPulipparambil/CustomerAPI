using AutoMapper;
using CustomerAPI.DTO;
using CustomerAPI.Models;

namespace CustomerAPI.Profiles
{
    public class CustomerOrderProfile : Profile
    {
        public CustomerOrderProfile() 
        {
            CreateMap<CustomerOrderInfo, CustomerOrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name ))
                .ForMember(dest => dest.ProductCost, opt => opt.MapFrom(src => src.Product.Cost))
                .ReverseMap();
        }
    }
}
