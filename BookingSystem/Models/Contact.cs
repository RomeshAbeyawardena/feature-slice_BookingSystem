using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookingSystem.Contracts;
using EContactType = BookingSystem.Enumerations.ContactType;
namespace BookingSystem.Models;

[Table(nameof(Contact))]
public record Contact : IContact {

    public Contact()
    {
        ContactAddresses = new List<ContactAddress>();
    }

    [Key]
    public Guid? Id { get; set; }
    public Guid ContactTypeId {get; set;}
    [Required, 
        RST.Attributes.ColumnDescriptor(
        System.Data.SqlDbType.NVarChar, 20)]
    public string? Title { get; set; }
    [Required,
     RST.Attributes.ColumnDescriptor(
        System.Data.SqlDbType.NVarChar, 80)]
    public string? FirstName { get; set; }
    [RST.Attributes.ColumnDescriptor(
        System.Data.SqlDbType.NVarChar, 80)]
    public string? MiddleName { get; set; }
    [Required,
     RST.Attributes.ColumnDescriptor(
        System.Data.SqlDbType.NVarChar, 80)]
    public string? LastName { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }

    [NotMapped]
    public EContactType? Type => ContactType != null 
        && Enum.TryParse<EContactType>(ContactType.Name, out var type)
        ? type : null;

    public virtual ContactType? ContactType { get; set; }

    public virtual ICollection<ContactAddress> ContactAddresses { get; set; }
}