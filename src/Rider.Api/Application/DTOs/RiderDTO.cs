namespace myRiderSharing.RiderApi.Application.DTOs;

public record RiderDTO
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal Rating { get; set; }

    public static RiderDTO FromEntityToDTO(Rider rider)
        => new RiderDTO
        {
            Id = rider.Id,
            FullName = rider.FullName,
            Email = rider.Email,
            PhoneNumber = rider.PhoneNumber,
            Rating = rider.Rating
        };
}