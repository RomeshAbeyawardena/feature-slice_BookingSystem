using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingSystem.Features.ContactType.Get;
using BookingSystem.Features.ContactType.Save;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RST.DependencyInjection.Extensions.Attributes;

namespace BookingSystem.Api.Features.ContactType;

[ApiController, Route(ROUTE_URL)]
public class Controller : RST.DependencyInjection.Extensions.EnableInjectionBase<InjectAttribute>
{
    const string ROUTE_URL = $"{Api.API_BASE_URL}/ContactType";
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }
    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        base.ConfigureInjection();
    }

    [HttpGet, Route("{contactTypeId?}")]
    public async Task<IEnumerable<ContactType>> GetContactTypes([FromQuery]Query query, CancellationToken cancellationToken, [FromRoute]Guid? contactTypeId)
    {
        query.ContactTypeId = contactTypeId;
        var q = await Mediator!.Send(query, cancellationToken);
        return await q
            .ProjectTo<ContactType>(Mapper!.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }

    [HttpPost]
    public async Task<ContactType> SaveContactTypes([FromForm]Command command, CancellationToken cancellationToken)
    {
        return Mapper!.Map<ContactType>(await Mediator!.Send(command, cancellationToken));
    }
}
