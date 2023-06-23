using BookingSystem.Contracts;

namespace BookingSystem.Models;

public record County : ICounty {
    public Guid? Id { get; set; }
    public Guid CountryId { get; set; }
    public string? Name { get; set; }

    public virtual Country? Country { get; set; }
}