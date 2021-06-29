using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sadad.Core.ApplicationService.Dtos.UserDto;
using Sadad.Core.Entities.Model;

namespace SadadWebApi.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {

            CreateMap<User, UserOutputDto>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.Name, o => o.MapFrom(p => p.Name))
                .ForMember(x => x.Gender, o => o.MapFrom(p => p.Gender))
                .ForMember(x => x.BirthDate, o => o.MapFrom(p => p.BirthDate))
                .ForMember(x => x.EmailAddress, o => o.MapFrom(p => p.EmailAddress));

            CreateMap<UserInputDto, User>()
        .ForMember(x => x.Name, o => o.MapFrom(p => p.Name))
        .ForMember(x => x.Gender, o => o.MapFrom(p => p.Gender))
        .ForMember(x => x.BirthDate, o => o.MapFrom(p => p.BirthDate))
        .ForMember(x => x.EmailAddress, o => o.MapFrom(p => p.EmailAddress));

            CreateMap<UserUpdateDto, User>()
       .ForMember(x => x.Name, o => o.MapFrom(p => p.Name))
       .ForMember(x => x.Gender, o => o.MapFrom(p => p.Gender))
       .ForMember(x => x.BirthDate, o => o.MapFrom(p => p.BirthDate))
       .ForMember(x => x.EmailAddress, o => o.MapFrom(p => p.EmailAddress));
        }
    }
}
