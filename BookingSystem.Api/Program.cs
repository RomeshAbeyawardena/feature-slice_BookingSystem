using RST.Extensions;
using BookingSystem;
using BookingSystem.Api;
using Microsoft.OpenApi.Models;
using System.Data;
using BookingSystem.Extensions;
using Microsoft.Data.SqlClient;

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
    .AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Booking System API",
        Version = "v1"
    }));

var app = builder.Build();

app.MapControllers();

app.MapGet("/", async (s) =>
{
    using var connection = s.RequestServices.GetRequiredService<IDbConnection>();
    Exception? lastException = default;

    var connectionCheck = Task.Run(() =>
    {
        bool connectionSuccessful = false;
        try
        {
            connection.Open();
            connectionSuccessful = true;
        }
        catch (Exception exception)
        {
            lastException = exception;
        }
        return connectionSuccessful;
    });
    var applicationSettings = s.RequestServices.GetRequiredService<ApplicationSettings>();
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
});
app.UseSwagger();
await app.RunAsync();
