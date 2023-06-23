using BookingSystem.Contracts;

namespace BookingSystem.Api.Features.ContactType;

public class ContactType : IContactType
{
    public Guid? Id { get; set; }
    public string? DisplayName { get; set; }
    public string? Name { get; set; }
}
