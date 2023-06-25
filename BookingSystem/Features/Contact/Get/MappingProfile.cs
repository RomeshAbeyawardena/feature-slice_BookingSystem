using AutoMapper;

namespace BookingSystem.Features.Contact.Get;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PagedQuery, Query>();
    }
}
