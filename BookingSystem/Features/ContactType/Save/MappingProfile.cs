using AutoMapper;

namespace BookingSystem.Features.ContactType.Save;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Command, Models.ContactType>();
    }
}
