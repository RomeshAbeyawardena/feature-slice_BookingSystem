using BookingSystem.Contracts;

namespace BookingSystem.Models;

public record Country : ICountry {
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? ShortName { get; set; }
}