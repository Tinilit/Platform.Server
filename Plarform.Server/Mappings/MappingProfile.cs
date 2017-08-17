﻿using AutoMapper;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<BrandUrlResolver>())
                .ForMember(s => s.BrandName, opt => opt.MapFrom(x => x.Name))
                .ReverseMap()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => x.BrandName));

            CreateMap<User, ProfileModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<ProfileUrlResolver>())
                .ReverseMap();

            CreateMap<Test, TestModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<TestUrlResolver>())
                .ReverseMap();

            CreateMap<TestType, TestTypeModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<TestTypeUrlResolver>())
                .ReverseMap();
        }
    }
}