using AutoMapper;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Models;

namespace CustomerManagementModule.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerType, CustomerTypeDto>().ReverseMap();
            CreateMap<CustomerContact, CustomerContactDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerAddressMap, CustomerAddressMapDto>().ReverseMap();
            CreateMap<CustomerCustomerTypeMap, CustomerCustomerTypeMapDto>().ReverseMap();
        }
    }
}
