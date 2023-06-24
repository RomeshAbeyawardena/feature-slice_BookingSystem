namespace BookingSystem.Api;

public record ApplicationSettings
{
    public ApplicationSettings(IConfiguration configuration)
    {
        configuration.Bind(this);
        ConnectionString = string.IsNullOrWhiteSpace(DefaultConnectionStringName) 
            ? string.Empty
            : configuration.GetConnectionString(DefaultConnectionStringName);
    }

    public string? DefaultConnectionStringName { get; set; }
    public string? EnvironmentName { get; set; }
    public string? ConnectionString { get; set; }
}
