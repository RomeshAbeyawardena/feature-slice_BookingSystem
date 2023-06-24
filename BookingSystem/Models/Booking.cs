using BookingSystem.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models;
[Table(nameof(Booking))]
public record Booking : IBooking {
    [Key]
    public Guid? Id { get; set; }
    public Guid? RecipientContactId { get; set; }
    public Guid? SenderContactId { get; set; }
    public Guid? ContactAddressId { get; set; }
    public DateTimeOffset StartDate { get; set;}
    public DateTimeOffset? EndDate { get; set; }
    public DateTimeOffset AcknowledgementDate { get; set;}
    public DateTimeOffset ConfirmationDate { get; set;}
    public DateTimeOffset  CancellationDate { get; set;}
    public virtual Contact? RecipientContact { get; set; }
    public virtual Contact? SenderContact { get; set; }
}