using BookingSystem.Enumerations;

namespace BookingSystem.Contracts;

public interface IContactTypeQuery
{
    ContactType? ContactType { get; set; }
    Guid? ContactTypeId { get; set; }
    string? NameSearch { get; set; }
}
