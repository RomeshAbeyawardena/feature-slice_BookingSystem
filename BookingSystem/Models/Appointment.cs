using BookingSystem.Contracts;
using EAppointmentType = BookingSystem.Enumerations.AppointmentType;
namespace BookingSystem.Models;

public record Appointment : IAppointment {
    public Guid? Id { get; set; }
    public Guid? AppointmentTypeId { get; set; }
    public Guid? BookingId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? AgreedStartDate { get; set; }
    public DateTimeOffset? AgreedEndDate { get; set; }
    public virtual AppointmentType? AppointmentType { get; set; }
    public EAppointmentType? Type => AppointmentType == null
        ? null
        : Enum.TryParse<EAppointmentType>(AppointmentType.Name, out var appointmentType)
            ? appointmentType : null;
    public virtual Booking? Booking { get; set; }
}