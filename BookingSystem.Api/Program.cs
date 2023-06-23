using RST.Extensions;
using BookingSystem;
using BookingSystem.Api;
using Microsoft.OpenApi.Models;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var assemblies = new[]
{
    "BookingSystem","BookingSystem.Api"
}.LoadAssemblies().ToArray();

var services = builder.Services;

services
    .AddAutoMapper(assemblies)
    .AddSingleton<ApplicationSettings>()
    .AddServices<ApplicationSettings>(a => a.ConnectionString)
    .AddMediatR(configure => configure
        .RegisterServicesFromAssemblies(assemblies))
    .AddControllers();
services
    .AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { 
            Title = "Booking System API",
            Version = "v1"
        }));

var app = builder.Build();

app.MapControllers();

app.MapGet("/", async(s) => {
    var connection = s.RequestServices.GetRequiredService<IDbConnection>();

    bool isDebug = false;
#if DEBUG
    isDebug = true;
#endif
    await s.Response.WriteAsync($"Connection string: {
        (isDebug ? connection.ConnectionString : "Truncated")
    }");
});
app.UseSwagger();
app.Run();
