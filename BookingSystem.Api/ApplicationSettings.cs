namespace BookingSystem.Api;

public record ApplicationSettings
{
    public ApplicationSettings(IConfiguration configuration)
    {
        configuration.Bind(this);
        ConnectionString = string.IsNullOrWhiteSpace(DefaultConnectionStringName) 
            ? string.Empty
            : configuration.GetConnectionString(DefaultConnectionStringName);
        StartedRunningTimestamp = DateTime.Now;
    }

    public string? DefaultConnectionStringName { get; set; }
    public string? EnvironmentName { get; set; }
    public string? ConnectionString { get; set; }
    public DateTimeOffset? LastSuccessfulDatabaseCheckTimestamp { get; set; }
    public DateTimeOffset StartedRunningTimestamp { get; }
}
