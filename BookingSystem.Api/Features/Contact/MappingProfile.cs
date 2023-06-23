using AutoMapper;

namespace BookingSystem.Api.Features.Contact;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Contact, Contact>();
    }
}
