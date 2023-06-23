using BookingSystem.Contracts;

namespace BookingSystem.Features.Contact.Get;

public record PagedQuery : IContactQuery
{
    public Enumerations.ContactType? ContactType { get; set; }
    public Guid? ContactTypeId { get; set; }
    public string? NameSearch { get; set; }
}
