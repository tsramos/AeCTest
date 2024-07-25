using AecTest.Core.Entities;
using AeCTest.Web.Models;
using AutoMapper;

namespace AeCTest.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EnderecoViewModel, Endereco>().ReverseMap();
        }
    }
}
