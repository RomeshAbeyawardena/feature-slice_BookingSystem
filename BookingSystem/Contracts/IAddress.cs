namespace BookingSystem.Contracts;

public interface IAddress 
{
    Guid? CountyId { get; set;}
    string? BuildingNumber { get; set; }
    string? BuildingName { get; set; }
    string? StreetNumber { get; set; }
    string? StreetName { get; set; }
    string? Area { get; set; }
    string? Region { get; set;}   
}