using AutoMapper;

namespace BookingSystem.Api.Features.ContactType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.ContactType, ContactType>();
    }
}
