using BookingSystem.Contracts;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models;
[Table(nameof(Country))]
public record County : ICounty {
    [Key]
    public Guid? Id { get; set; }
    public Guid CountryId { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Name { get; set; }

    public virtual Country? Country { get; set; }
}