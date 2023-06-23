using BookingSystem.Contracts;
using MediatR;
using RST.Contracts;

namespace BookingSystem.Features.ContactType.Save;

public record Command : IRequest<Models.ContactType>, IContactType, IDbCommand
{
    public Guid? Id { get; set; }
    public string? DisplayName { get; set; }
    public string? Name { get; set; }
    public bool CommitChanges { get; set; }
}
