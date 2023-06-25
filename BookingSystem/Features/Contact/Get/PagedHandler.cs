using AutoMapper;
using MediatR;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace BookingSystem.Features.Contact.Get;

public class PagedHandler : PagedRepositoryHandlerBase<PagedQuery, Models.Contact>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }
    
    public PagedHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<IPagedResult<Models.Contact>> Handle(PagedQuery request, CancellationToken cancellationToken)
    {
        var query = await Mediator!.Send(Mapper!.Map<Query>(request), cancellationToken);
        return await base.ProcessPagedQuery(query, request, cancellationToken);
    }
}
