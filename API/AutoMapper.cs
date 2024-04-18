using AutoMapper;

namespace SharpApi.Mapper;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        //SOURCE -> DESTINATION
        _ = CreateMap<User, GetUserInfosDto>();
    }
}