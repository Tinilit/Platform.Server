﻿using Plarform.Server.Models;
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

            CreateMap<Profile, ProfileModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<ProfileUrlResolver>())
                .ReverseMap()
                .ForMember(s => s.User, opt => opt.Ignore())
                .ForMember(s => s.UserId, opt => opt.Ignore());


            CreateMap<Test, TestModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<TestUrlResolver>())
                .ForMember(s => s.ProviderProfile, opt => opt.MapFrom(x => x.Provider.Profile))
                .ReverseMap()
                .ForMember(s => s.Provider, opt => opt.Ignore());

            CreateMap<TestType, TestTypeModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<TestTypeUrlResolver>())
                .ReverseMap();

            CreateMap<UserTest, UserTestModel>()
                .ForMember(s => s.Url, opt => opt.ResolveUsing<UserTestUrlResolver>())
                .ForMember(s => s.UserProfile, opt => opt.MapFrom(x => x.User.Profile))
                .ReverseMap()
                .ForMember(s => s.User, opt => opt.Ignore());

            CreateMap<User, UserModel>()
                .ForMember(s=>s.Profile, opt=>opt.MapFrom(x=>x.Profile))
                .ForMember(s => s.UserId, opt => opt.MapFrom(x => x.Id));

        }
    }
}