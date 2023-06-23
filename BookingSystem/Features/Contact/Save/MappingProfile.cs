using AutoMapper;

namespace BookingSystem.Features.Contact.Save;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Command, Models.Contact>();
    }
}
