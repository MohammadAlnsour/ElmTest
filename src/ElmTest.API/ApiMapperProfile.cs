using AutoMapper;
using ElmTest.Application.Requests;
using ElmTest.Domain.Entities;

namespace ElmTest.API
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<CreateBookRequest, BookInfo>().ReverseMap();
        }
    }
}
