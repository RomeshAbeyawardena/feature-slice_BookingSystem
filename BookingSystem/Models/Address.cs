using BookingSystem.Contracts;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models;

[Table(nameof(Address))]
public record Address : IAddress {
    [Key]
    public Guid? Id { get; set; }
    public Guid? CountyId { get; set;}
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? BuildingNumber { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? BuildingName { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? StreetNumber { get; set; }
    [ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? StreetName { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Area { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Region { get; set;}
    public virtual County? County { get; set;}
}