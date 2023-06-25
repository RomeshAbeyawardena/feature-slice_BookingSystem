using BookingSystem.Contracts;
using RST.Contracts;
using RST.Enumerations;

namespace BookingSystem.Features.ContactType.Get;

public record PagedQuery : IPagedRequest<Models.ContactType>, IContactQuery
{
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
    public Enumerations.ContactType? ContactType { get; set; }
    public Guid? ContactTypeId { get; set; }
    public string? NameSearch { get; set; }
}
