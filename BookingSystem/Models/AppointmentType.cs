using BookingSystem.Contracts;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EAppointmentType = BookingSystem.Enumerations.AppointmentType;

namespace BookingSystem.Models;

[Table(nameof(AppointmentType))]
public record AppointmentType : IAppointmentType
{
    [Key]
    public Guid? Id { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 80)]
    public string? Name { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? DisplayName { get; set; }

    public EAppointmentType? Type => Enum
        .TryParse<EAppointmentType>(Name, out var appointmentType) 
        ? appointmentType : null; 
}