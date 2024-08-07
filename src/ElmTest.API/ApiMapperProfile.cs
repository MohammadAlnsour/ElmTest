using AutoMapper;
using ElmTest.Application.Contracts.DTOs;
using ElmTest.Application.Requests;
using ElmTest.Domain.Entities;
using Newtonsoft.Json;

namespace ElmTest.API
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<CreateBookRequest, BookInfo>().ReverseMap();
            CreateMap<Book, BookReponseDTO>().ReverseMap();
        }
    }
}
