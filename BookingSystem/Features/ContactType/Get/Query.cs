using BookingSystem.Contracts;
using MediatR;

namespace BookingSystem.Features.ContactType.Get;

public record Query : IRequest<IQueryable<Models.ContactType>>, IContactTypeQuery
{
    public Enumerations.ContactType? ContactType { get; set; }
    public Guid? ContactTypeId { get; set; }
    public string? NameSearch { get; set; }
}
