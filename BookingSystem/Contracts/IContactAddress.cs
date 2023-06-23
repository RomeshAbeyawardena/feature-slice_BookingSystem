namespace BookingSystem.Contracts;

public interface IContactAddress {
    Guid ContactId { get; set; }
    Guid AddressId { get; set; }
    string? Alias { get; set; }
    bool IsPrimary { get; set; }
}