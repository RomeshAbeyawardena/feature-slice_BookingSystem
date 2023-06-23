using Microsoft.EntityFrameworkCore;

namespace BookingSystem;

public class BookingSystemDbContext : DbContext
{
    public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Models.Contact> Contacts { get; set; }
    public DbSet<Models.ContactType> ContactTypes { get; set; }
}
