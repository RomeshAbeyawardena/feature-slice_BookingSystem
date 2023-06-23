using BookingSystem.Contracts;

namespace BookingSystem.Models;

public record Address : IAddress {
    public Guid? Id { get; set; }
    public Guid? CountyId { get; set;}
    public string? BuildingNumber { get; set; }
    public string? BuildingName { get; set; }
    public string? StreetNumber { get; set; }
    public string? StreetName { get; set; }
    public string? Area { get; set; }
    public string? Region { get; set;}
    public virtual County? County { get; set;}
}