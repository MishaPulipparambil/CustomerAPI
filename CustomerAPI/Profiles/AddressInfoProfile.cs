using AutoMapper;
using CustomerAPI.DTO;
using CustomerAPI.Models;

namespace CustomerAPI.Profiles
{
    public class AddressInfoProfile: Profile
    {
         public AddressInfoProfile() 
          {
            CreateMap<AddressInfo, AddressInfoDto>().ReverseMap();
          }
    }
}
