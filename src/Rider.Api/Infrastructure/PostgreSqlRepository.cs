using myRiderSharing.RiderApi.Application.Models;

namespace myRiderSharing.RiderApi.Infrastructure;

public class PostgreSqlRepository : IRiderRepository
{
    public Task<Rider> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Rider rider)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}