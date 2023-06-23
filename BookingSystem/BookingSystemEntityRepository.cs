using BookingSystem.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Subjects;

namespace BookingSystem;

public class BookingSystemEntityRepository<T> : RST.EntityFrameworkCore.EntityFrameworkRepositoryBase<BookingSystemDbContext, T>
    where T : class
{
    public BookingSystemEntityRepository(BookingSystemDbContext context, ISubject<ExpressionStarter<T>> subject) : base(context, subject)
    {

    }
    
     public DbSet<Address>? Addresses { get; set; }
     public DbSet<Appointment>? Appointments { get; set; }
     public DbSet<AppointmentType>? AppointmentTypes { get; set; }
     public DbSet<Booking>? Bookings { get; set; }
    
    public DbSet<Contact>? Contacts { get; set; }
    
    public DbSet<ContactAddress>? ContactAddresses { get; set; }
    
    public DbSet<ContactType>? ContactTypes { get; set; }
    
    public DbSet<Country>? Countries { get; set; }
    
    public DbSet<County>? Counties { get; set; }
}
