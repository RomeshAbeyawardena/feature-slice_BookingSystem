using AutoMapper;
using BookingSystem.Features.Contact.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using RST.DependencyInjection.Extensions.Attributes;
using BookingSystem.Features.Contact.Save;

namespace BookingSystem.Api.Features.Contact;

[ApiController, Route(ROUTE_URL)]
public class Controller : RST.DependencyInjection.Extensions.EnableInjectionBase<InjectAttribute>
{
    const string ROUTE_URL = $"{Api.API_BASE_URL}/Contact";
    [Inject] protected IMediator? mediator { get; set; }
    [Inject] protected IMapper? mapper { get; set; }

    public Controller(IServiceProvider services)
        : base(services)
    {
        base.ConfigureInjection();
    }

    [HttpGet, Route("{contactId?}")]
    public async Task<IEnumerable<Contact>> GetContacts([FromQuery]Query query, CancellationToken cancellationToken, [FromRoute]Guid? contactId)
    {
        query.ContactId = contactId;
        var response = await mediator!.Send(query, cancellationToken);
        return await response
            .ProjectTo<Contact>(mapper!.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }

    [HttpPost]
    public async Task<Contact> SaveContactTypes([FromForm]Command command, CancellationToken cancellationToken)
    {
        return mapper!.Map<Contact>(
            await mediator!.Send(command, cancellationToken));
    }
}
