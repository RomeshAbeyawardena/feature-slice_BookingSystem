namespace BookingSystem.Contracts;

public interface IAppointment {
    Guid? AppointmentTypeId { get; set; }
    Guid? BookingId { get; set; }
    string? Description { get; set; }
    DateTimeOffset? AgreedStartDate { get; set; }
    DateTimeOffset? AgreedEndDate { get; set; }
}