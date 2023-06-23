using BookingSystem.Contracts;
using MediatR;

namespace BookingSystem.Features.Contact.Get;

public record Query : IContactQuery, IRequest<IQueryable<Models.Contact>>
{
    public Enumerations.ContactType? ContactType { get; set; }
    public Guid? ContactTypeId { get; set; }
    public Guid? ContactId { get; set; }
    public string? NameSearch { get; set; }
}
