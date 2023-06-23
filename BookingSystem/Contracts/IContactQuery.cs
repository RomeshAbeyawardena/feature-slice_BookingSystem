using BookingSystem.Enumerations;

namespace BookingSystem.Contracts;

public interface IContactQuery
{
    ContactType? ContactType { get; set; }
    Guid? ContactTypeId { get; set; }
    string? NameSearch { get; set; }
}
