using BookingSystem.Contracts;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models;

[Table(nameof(Country))]
public record Country : ICountry {
    [Key]
    public Guid? Id { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Name { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 2000)]
    public string? ShortName { get; set; }
}