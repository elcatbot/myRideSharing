namespace myRiderSharing.RiderApi.Infrastructure;

public class SqlRepository(RiderDbContext Context) : IRiderRepository
{
    public async Task<Rider> GetByIdAsync(int id)
        => (await Context.Riders.FirstOrDefaultAsync(r => r.Id == id))!;

    public async Task AddAsync(Rider rider)
        => await Context.Riders.AddAsync(rider);

    public async Task SaveChangesAsync()
        => await Context.SaveChangesAsync();

    public async Task UpdateAsync(Rider rider)
        => Context.Entry(rider).State = EntityState.Modified;

}