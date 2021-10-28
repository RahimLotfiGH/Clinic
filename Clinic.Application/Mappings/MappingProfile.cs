using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Domain.Entities;

namespace Clinic.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserForCreationDto, AppUser>();
            CreateMap<AppUserForUpdateDto, AppUser>();
        }
    }
}
