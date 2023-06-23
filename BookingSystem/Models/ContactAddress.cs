using BookingSystem.Contracts;

namespace BookingSystem.Models;

public record ContactAddress : IContactAddress
{
    public Guid? Id { get; set; }
    public Guid ContactId { get; set; }
    public Guid AddressId { get; set; }
    public string? Alias { get; set; }
    public bool IsPrimary { get; set; }
    public virtual Contact? Contact { get; set; }
    public virtual Address? Address { get; set; }
}
