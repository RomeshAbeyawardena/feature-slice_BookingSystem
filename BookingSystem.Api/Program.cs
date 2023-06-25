using RST.Extensions;
using BookingSystem;
using BookingSystem.Api;
using Microsoft.OpenApi.Models;
using System.Data;
using BookingSystem.Extensions;

var builder = WebApplication.CreateBuilder(args);
var assemblies = new[]
{
    "BookingSystem",
    "BookingSystem.Api"
}.LoadAssemblies()
.ToArray();

var services = builder.Services;

services
    .AddAutoMapper(assemblies)
    .AddSingleton<ApplicationSettings>()
    .AddServices<ApplicationSettings>(a => a.ConnectionString)
    .AddMediatR(configure => configure
        .RegisterServicesFromAssemblies(assemblies))
    .AddControllers();
services
    .AddSwaggerGen(c => {
        c.CustomSchemaIds(c => c.FullName); 
        c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Booking System API",
        Version = "v1"
    }); });

var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();
app.MapGet("/", async (s) =>
{
    var applicationSettings = s.RequestServices.GetRequiredService<ApplicationSettings>();
    using var connection = s.RequestServices.GetRequiredService<IDbConnection>();
    Exception? lastException = default;

    var connectionCheck = Task.FromResult(true);
    var dateNow = DateTimeOffset.UtcNow;
    var hasConnectionBeenCheckedNow = false;
    if (!applicationSettings
            .LastSuccessfulDatabaseCheckTimestamp.HasValue
        || dateNow.Subtract(applicationSettings
            .LastSuccessfulDatabaseCheckTimestamp.Value).TotalMinutes > 15)
    {
        connectionCheck = Task.Run(() =>
        {
            bool connectionSuccessful = false;
            try
            {
                connection.Open();
                connectionSuccessful = true;
                hasConnectionBeenCheckedNow = true;
                applicationSettings
                    .LastSuccessfulDatabaseCheckTimestamp = DateTime.UtcNow;
            }
            catch (Exception exception)
            {
                lastException = exception;
            }
            return connectionSuccessful;
        });
    }

    bool isDebug = false;
#if DEBUG
    isDebug = true;
#endif
    var response = s.Response;
    await response.WriteAsync("<!DOCTYPE html><html lang=\"en-GB\"><meta charset=\"utf-8\" /><meta name=\"viewport\" content=\"width=device-width\" /><head><title>Booking System API - Server Status</title><link rel=\"stylesheet\" href=\"/normalise.css\" /><link rel=\"stylesheet\" href=\"/index.css\" /><link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\r\n<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\r\n<link href=\"https://fonts.googleapis.com/css2?family=Antic+Slab&display=swap\" rel=\"stylesheet\"></head><body><div class=\"content\">");
    await response
        .WriteAsync($"<h2>Server status</h2><p><span class=\"title\">Environment Name:</span>{applicationSettings.EnvironmentName} {isDebug.IIf("(Development)</p>", string.Empty)}");
    await response
            .WriteAsync($"<p><span class=\"title\">{isDebug.IIf("Connection string", "Database name")}:</span>{isDebug.IIf(connection.ConnectionString, connection.Database)}</p>");
    await response
        .WriteAsync($"<p><span class=\"title\">Connection status:</span>{(await connectionCheck)
            .IIf($"Successful {hasConnectionBeenCheckedNow.IIf(string.Empty, "(Cached)")}", 
                $"Failed: {lastException?.Message}")}</p>");
    
    if (applicationSettings.LastSuccessfulDatabaseCheckTimestamp.HasValue)
    {
        await response
            .WriteAsync($"<p><span class=\"title\">Last connection check:</span> {dateNow.Subtract(
                applicationSettings.LastSuccessfulDatabaseCheckTimestamp.Value)}</p>");
    }

    await response
        .WriteAsync($"<p><span class=\"title\">Uptime:</span>{dateNow.Subtract( 
            applicationSettings.StartedRunningTimestamp)}</p>");

    await response.WriteAsync("</div></body></html>");
});
app.UseSwagger();
await app.RunAsync();
