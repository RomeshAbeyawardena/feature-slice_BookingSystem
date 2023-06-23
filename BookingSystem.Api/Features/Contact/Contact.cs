using BookingSystem.Contracts;

namespace BookingSystem.Api.Features.Contact
{
    public class Contact : IContact
    {
        public Guid ContactTypeId { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
    }
}
