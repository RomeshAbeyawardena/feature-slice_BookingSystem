using BookingSystem.Contracts;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EAppointmentType = BookingSystem.Enumerations.AppointmentType;
namespace BookingSystem.Models;

[Table(nameof(Appointment))]
public record Appointment : IAppointment {
    [Key]
    public Guid? Id { get; set; }
    public Guid? AppointmentTypeId { get; set; }
    public Guid? BookingId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? Description { get; set; }
    public DateTimeOffset? AgreedStartDate { get; set; }
    public DateTimeOffset? AgreedEndDate { get; set; }
    public virtual AppointmentType? AppointmentType { get; set; }
    [NotMapped]
    public EAppointmentType? Type => AppointmentType == null
        ? null
        : Enum.TryParse<EAppointmentType>(AppointmentType.Name, out var appointmentType)
            ? appointmentType : null;
    public virtual Booking? Booking { get; set; }
}