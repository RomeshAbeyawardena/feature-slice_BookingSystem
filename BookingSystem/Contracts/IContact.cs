namespace BookingSystem.Contracts;

public interface IContact {
    Guid ContactTypeId {get; set;}
    string? Title { get; set; }
    string? FirstName { get; set; }
    string? MiddleName { get; set; }
    string? LastName { get; set; }
    DateTimeOffset RegistrationDate { get; set; }
}