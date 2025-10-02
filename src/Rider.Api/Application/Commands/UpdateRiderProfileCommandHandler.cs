namespace myRiderSharing.RiderApi.Application.Commands;

public class UpdateRiderProfileCommandHandler(IRiderRepository Repository) : IRequestHandler<UpdateRiderProfileCommand, bool>
{
    public async Task<bool> Handle(UpdateRiderProfileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var rider = await Repository.GetByIdAsync(request.Id);
            if (rider == null)
            {
                return false;
            }

            rider.FullName = request.FullName;
            rider.Email = request.Email;
            rider.PhoneNumber = request.PhoneNumber;
            rider.Rating = request.Rating;
            rider.UpdatedAt = DateTime.Now;

            await Repository.UpdateAsync(rider);
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
