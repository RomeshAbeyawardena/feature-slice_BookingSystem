using AutoMapper;
using RST.Contracts;
using RST.Defaults;

namespace BookingSystem.Api.Features.Contact;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Contact, Contact>();
        CreateMap(typeof(IPagedResult<>), typeof(IPagedResult<>))
            .ConstructUsing(PageResultConstructor);
    }

    private object PageResultConstructor(object arg1, ResolutionContext arg2)
    {
        throw new NotImplementedException();
    }
}
