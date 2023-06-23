using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;
using RST.DependencyInjection.Extensions;
using RST.EntityFrameworkCore.Extensions;
using Microsoft.Data;
using System.Data;
using System.Data.SqlClient;

namespace BookingSystem;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices<TApplicationServices>(this IServiceCollection services, Func<TApplicationServices, string?> getConnectionString)
        where TApplicationServices : class
    {
        return services
            .AddTransient<IDbConnection>(s =>
            {
                var applicationServices = s.GetRequiredService<TApplicationServices>();
                var connectionString = getConnectionString(applicationServices);

                return new SqlConnection(connectionString); 
            })
            .AddCoreServices()
            .AddDbContextAndRepositories<BookingSystemDbContext>(typeof(BookingSystemEntityRepository<>), (s,opt) => {
                var applicationServices = s.GetRequiredService<TApplicationServices>();
                var connectionString = getConnectionString(applicationServices);
                if (!string.IsNullOrEmpty(connectionString))
                {
                    opt.UseSqlServer(connectionString);
                }
            });
    }
}
