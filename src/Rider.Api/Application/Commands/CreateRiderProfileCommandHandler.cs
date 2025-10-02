namespace myRiderSharing.RiderApi.Application.Commands;

public class CreateRiderProfileCommandHandler(IRiderRepository Repository) : IRequestHandler<CreateRiderProfileCommand, bool>
{
    public async Task<bool> Handle(CreateRiderProfileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var rider = new Rider
            {
                UserId = 1,
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Rating = request.Rating,
                CreatedAt = DateTime.Now
            };

            await Repository.AddAsync(rider);
            await Repository.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }
}
