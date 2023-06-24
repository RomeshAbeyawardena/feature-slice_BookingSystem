using BookingSystem.Contracts;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models;

public record ContactAddress : IContactAddress
{
    [Key]
    public Guid? Id { get; set; }
    public Guid ContactId { get; set; }
    public Guid AddressId { get; set; }
    [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
    public string? Alias { get; set; }
    public bool IsPrimary { get; set; }
    public virtual Contact? Contact { get; set; }
    public virtual Address? Address { get; set; }
}
