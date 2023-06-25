using AutoMapper;
using MediatR;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;
using System.Data.Entity.Core.Metadata.Edm;

namespace BookingSystem.Features.ContactType.Get;

public class PagedHandler : PagedRepositoryHandlerBase<PagedQuery, Models.ContactType>
{
    [Inject]
    protected IMediator? Mediator { get; set; }
    [Inject]
    protected IMapper? Mapper { get; set; }

    public PagedHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IPagedResult<Models.ContactType>> Handle(PagedQuery request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(Mapper!.Map<Query>(request), cancellationToken);
        return await ProcessPagedQuery(query, request, cancellationToken);
    }
}
