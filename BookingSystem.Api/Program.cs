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

app.MapGet("/", async (s) =>
{
    var applicationSettings = s.RequestServices.GetRequiredService<ApplicationSettings>();
    using var connection = s.RequestServices.GetRequiredService<IDbConnection>();
    Exception? lastException = default;

    var connectionCheck = Task.FromResult(true);

    if (!applicationSettings.LastSuccessfulDatabaseCheckTimestamp.HasValue
        || DateTimeOffset.UtcNow.Subtract(applicationSettings.LastSuccessfulDatabaseCheckTimestamp.Value).TotalMinutes > 15)
    {
        connectionCheck = Task.Run(() =>
        {
            bool connectionSuccessful = false;
            try
            {
                connection.Open();
                connectionSuccessful = true;
                applicationSettings.LastSuccessfulDatabaseCheckTimestamp = DateTime.UtcNow;
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
    await response
        .WriteAsync($"Environment Name: {applicationSettings.EnvironmentName} {isDebug.IIf("(Development)", string.Empty)}");
    await response
            .WriteAsync($"\r\n{isDebug.IIf("Connection string", "Database name")}: {isDebug.IIf(connection.ConnectionString, connection.Database)}");
    await response
        .WriteAsync($"\r\nConnection status: {(await connectionCheck).IIf("Successful", $"Failed: {lastException?.Message}")}");
    
    if (applicationSettings.LastSuccessfulDatabaseCheckTimestamp.HasValue)
    {
        await response
            .WriteAsync($"\r\nLast connection check: {DateTimeOffset.UtcNow.Subtract(
                applicationSettings.LastSuccessfulDatabaseCheckTimestamp.Value)}");
    }

    await response
        .WriteAsync($"\r\nUptime: {DateTimeOffset.UtcNow.Subtract( 
            applicationSettings.StartedRunningTimestamp)}");
});
app.UseSwagger();
await app.RunAsync();
