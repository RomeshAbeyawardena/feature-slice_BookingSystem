using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookingSystem.Contracts;
using EContactType = BookingSystem.Enumerations.ContactType;

namespace BookingSystem.Models;

[Table(nameof(ContactType))]
public record ContactType : IContactType {
    [Key]
    public Guid? Id { get; set; }
    [RST.Attributes.ColumnDescriptor(System.Data.SqlDbType.NVarChar, 80)]
    public string? DisplayName { get; set; }
    [RST.Attributes.ColumnDescriptor(System.Data.SqlDbType.NVarChar, 20)]
    public string? Name { get; set; }
    [NotMapped]
    public EContactType? Type => Enum
        .TryParse<EContactType>(Name, out var type)
            ? type : null;
}