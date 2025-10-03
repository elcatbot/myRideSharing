namespace myRiderSharing.RiderApi.Application.Models;

public record Rider
{
    public int Id { get; set; } 
    public int UserId { get; set; } 
    public string? FullName { get; set; } 
    public string? Email { get; set; } 
    public string? PhoneNumber { get; set; } 
    public decimal Rating { get; set; } 
    public DateTimeOffset CreatedAt { get; set; } 
    public DateTimeOffset UpdatedAt { get; set; } 
}