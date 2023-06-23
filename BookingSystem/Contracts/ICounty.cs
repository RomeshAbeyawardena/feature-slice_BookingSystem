namespace BookingSystem.Contracts;

public interface ICounty
{
    public Guid CountryId { get; set; }
    public string? Name { get; set; }
}
