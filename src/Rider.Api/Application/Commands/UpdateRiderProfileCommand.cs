namespace myRiderSharing.RiderApi.Application.Commands;

public record UpdateRiderProfileCommand : IRequest<bool>
{
    public int Id { get; set; } 
    public int UserId { get; set; } 
    public string? FullName { get; set; } 
    public string? Email { get; set; } 
    public string? PhoneNumber { get; set; } 
    public decimal Rating { get; set; } 
}