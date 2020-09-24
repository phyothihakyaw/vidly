using AutoMapper;
using Vidly.Web.Dtos;
using Vidly.Web.Models;

namespace Vidly.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
