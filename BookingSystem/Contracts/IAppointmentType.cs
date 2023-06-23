namespace BookingSystem.Contracts;

public interface IAppointmentType {
    string? Name { get; set; }
    string? DisplayName { get; set; }
}