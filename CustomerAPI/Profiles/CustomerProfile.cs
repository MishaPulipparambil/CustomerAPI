using AutoMapper;
using CustomerAPI.Models;

public class CustomerProfile :Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer,CustomerDto>()
            .ForMember(dest =>dest.BillingAddress, opt => opt.MapFrom(src => src.BillingAddress))
            .ForMember(dest => dest.MailingAddress, opt => opt.MapFrom(src => src.MailingAddress))
            .ReverseMap();
    }
}