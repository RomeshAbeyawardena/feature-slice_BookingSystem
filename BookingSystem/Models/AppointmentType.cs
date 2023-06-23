using BookingSystem.Contracts;
using EAppointmentType = BookingSystem.Enumerations.AppointmentType;

namespace BookingSystem.Models;

public record AppointmentType : IAppointmentType
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }

    public EAppointmentType? Type => Enum
        .TryParse<EAppointmentType>(Name, out var appointmentType) 
        ? appointmentType : null; 
}