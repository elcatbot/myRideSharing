namespace myRiderSharing.RiderApi.Infrastructure;

public interface IRiderRepository
{
    Task<Rider> GetByIdAsync(int id);
    Task AddAsync(Rider rider);
    Task UpdateAsync(Rider rider);
    Task SaveChangesAsync();
}