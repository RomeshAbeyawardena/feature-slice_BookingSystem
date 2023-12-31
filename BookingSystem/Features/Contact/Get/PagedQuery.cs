﻿using BookingSystem.Contracts;
using RST.Contracts;
using RST.Enumerations;

namespace BookingSystem.Features.Contact.Get;

public record PagedQuery : IPagedRequest<Models.Contact>, IContactQuery
{
    public Enumerations.ContactType? ContactType { get; set; }
    public Guid? ContactId { get; set; }
    public Guid? ContactTypeId { get; set; }
    public string? NameSearch { get; set; }
    public int? PageIndex { get; set; }
    public int? TotalItemsPerPage { get; set; }
    public IEnumerable<string>? OrderByFields { get; set; }
    public SortOrder? SortOrder { get; set; }
    public bool? NoTracking { get; set; }
}
