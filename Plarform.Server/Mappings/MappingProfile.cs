using System;
using AutoMapper;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(x => x.Url, opt => opt.ResolveUsing<CampUrlResolver>())
                .ReverseMap()
                .ForMember(x => x.EventDate,
                    opt => opt.ResolveUsing(c => c.EventDate != DateTime.MinValue ? c.EventDate : DateTime.Now))
                .ForMember(x => x.Location,
                    opt => opt.ResolveUsing(c => new Location()
                    {
                        Address1 = c.LocationAddress1,
                        Address2 = c.LocationAddress2,
                        Address3 = c.LocationAddress3,
                        CityTown = c.LocationCityTown,
                        StateProvince = c.LocationStateProvince,
                        Country = c.LocationCountry,
                        PostalCode = c.LocationPostalCode
                    }));
            CreateMap<Speaker, SpeakerModel>()
                .ForMember(s=>s.Url,opt=>opt.ResolveUsing<SpeakerUrlResolver>())
                .ReverseMap();
        }
    }
}
