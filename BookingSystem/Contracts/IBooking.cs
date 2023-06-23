namespace BookingSystem.Contracts;

public interface IBooking {
    Guid? RecipientContactId { get; set; }
    Guid? SenderContactId { get; set; }
    Guid? ContactAddressId { get; set; }
    DateTimeOffset StartDate { get; set;}
    DateTimeOffset? EndDate { get; set; }
    DateTimeOffset AcknowledgementDate { get; set;}
    DateTimeOffset ConfirmationDate { get; set;}
    DateTimeOffset  CancellationDate { get; set;}
}