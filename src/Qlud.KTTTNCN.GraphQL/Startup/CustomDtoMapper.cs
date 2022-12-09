using AutoMapper;
using Qlud.KTTTNCN.Authorization.Users;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Startup
{
    public static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserDto>()
                .ForMember(dto => dto.Roles, options => options.Ignore())
                .ForMember(dto => dto.OrganizationUnits, options => options.Ignore());
        }
    }
}