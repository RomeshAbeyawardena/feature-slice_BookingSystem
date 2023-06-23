using MediatR;
using Microsoft.EntityFrameworkCore;
using RST.Contracts;

namespace BookingSystem.Features.ContactType.Get;

public class Handler : IRequestHandler<Query, IQueryable<Models.ContactType>>
{
    private readonly IMediator mediator;
    private readonly IRepository<Models.ContactType> contactTypes;

    public Handler(IMediator mediator, IRepository<Models.ContactType> contactTypes)
    {
        this.mediator = mediator;
        this.contactTypes = contactTypes;
    }

    public async Task<IQueryable<Models.ContactType>> Handle(Query query, CancellationToken cancellationToken)
    {
        var builder = contactTypes.QueryBuilder;
        if (query.ContactType.HasValue)
        {
            var contactTypes = await mediator.Send(new Query
            {
                ContactType = query.ContactType
            }, cancellationToken);

            var contactType = await contactTypes
                .FirstOrDefaultAsync(cancellationToken);

            query.ContactTypeId = contactType?.Id;
        }

        if (query.ContactTypeId.HasValue)
        {
            builder.And(c => c.Id == query.ContactTypeId);
        }

        return contactTypes.Where(builder);
    }
}
