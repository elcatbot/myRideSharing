namespace myRiderSharing.RiderApi;

public record RiderConfigOptions()
{
    public string? ConnectionString { get; set; }
    public string? EventBusConnection { get; set; }
}