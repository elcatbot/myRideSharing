namespace myRiderSharing.RiderApi.Application.Commands.DTOs;

public record CreateRiderProfileCommand : IRequest<bool>
{
    public int UserId { get; set; } 
    public string? FullName { get; set; } 
    public string? Email { get; set; } 
    public string? PhoneNumber { get; set; } 
    public decimal Rating { get; set; } 
}