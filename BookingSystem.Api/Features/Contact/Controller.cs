using AutoMapper;
using BookingSystem.Features.Contact.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using RST.DependencyInjection.Extensions.Attributes;
using BookingSystem.Features.Contact.Save;
using RST.Contracts;

namespace BookingSystem.Api.Features.Contact;

[ApiController, Route(ROUTE_URL)]
public class Controller : RST.DependencyInjection.Extensions.EnableInjectionBase<InjectAttribute>
{
    const string ROUTE_URL = $"{Api.API_BASE_URL}/Contact";
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }

    public Controller(IServiceProvider services)
        : base(services)
    {
        base.ConfigureInjection();
    }

    [HttpGet, Route("{contactId?}")]
    public async Task<IPagedResult<Contact>> GetContacts([FromQuery]PagedQuery query, CancellationToken cancellationToken, [FromRoute]Guid? contactId)
    {
        query.ContactId = contactId;
        var response = await Mediator!.Send(query, cancellationToken);

        return Mapper!.Map<IPagedResult<Contact>>(response);
    }

    [HttpPost]
    public async Task<Contact> SaveContactTypes([FromForm]Command command, CancellationToken cancellationToken)
    {
        return Mapper!.Map<Contact>(
            await Mediator!.Send(command, cancellationToken));
    }
}
