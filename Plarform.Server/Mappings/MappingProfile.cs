using AutoMapper;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<BrandUrlResolver>())
                .ForMember(s => s.BrandName, opt => opt.MapFrom(x => x.Name))
                .ReverseMap()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => x.BrandName));
        }
    }
}
