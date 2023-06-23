using MediatR;
using Microsoft.EntityFrameworkCore;
using RST.Contracts;
using ContactTypeFeature = BookingSystem.Features.ContactType;
namespace BookingSystem.Features.Contact.Get;

public class Handler : IRequestHandler<Query, IQueryable<Models.Contact>>
{
    private readonly IMediator mediator;
    private readonly IRepository<Models.Contact> contacts;

    public Handler(IMediator mediator, IRepository<Models.Contact> contacts)
    {
        this.mediator = mediator;
        this.contacts = contacts;
    }

    public async Task<IQueryable<Models.Contact>> Handle(Query query, CancellationToken cancellationToken)
    {
        var builder = contacts.QueryBuilder;
        if (query.ContactType.HasValue)
        {
            var contactTypes = await mediator.Send(new ContactTypeFeature.Get.Query
            {
                ContactType = query.ContactType
            }, cancellationToken);

            var contactType = await contactTypes
                .FirstOrDefaultAsync(cancellationToken);

            query.ContactTypeId = contactType?.Id;
        }

        if(query.ContactTypeId.HasValue)
        {
            builder.And(c => c.ContactTypeId == query.ContactTypeId.Value);
        }

        if (!string.IsNullOrWhiteSpace(query.NameSearch))
        {
            var expression = $"%{query.NameSearch}%";
            builder.And(c => EF.Functions.Like(c.Title!, expression));
            builder.Or(c => EF.Functions.Like(c.FirstName!, expression));
            builder.Or(c => EF.Functions.Like(c.MiddleName!, expression));
            builder.Or(c => EF.Functions.Like(c.LastName!, expression));
        }

        return contacts.Where(builder);
    }
}
