using BookingSystem.Contracts;

namespace BookingSystem.Models;

public record Booking : IBooking {
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