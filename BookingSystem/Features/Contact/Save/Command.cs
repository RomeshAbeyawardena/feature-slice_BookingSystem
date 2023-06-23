using BookingSystem.Contracts;
using MediatR;
using RST.Contracts;

namespace BookingSystem.Features.Contact.Save;

public record Command : IRequest<Models.Contact>, IContact, IDbCommand
{
    public Guid? Id { get; set; }
    public Guid ContactTypeId { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }
    public bool CommitChanges { get; set; }
}
