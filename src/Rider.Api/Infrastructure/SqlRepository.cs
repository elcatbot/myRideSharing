namespace myRiderSharing.RiderApi.Infrastructure;

public class SqlRepository(RiderDbContext Context) : IRiderRepository
{
    public async Task<Rider> GetByIdAsync(int id)
        => (await Context.Riders.FirstOrDefaultAsync(r => r.Id == id))!;

    public Task AddAsync(Rider rider)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}