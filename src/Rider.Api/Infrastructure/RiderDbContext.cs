namespace myRiderSharing.RiderApi.Infrastructure;

public class RiderDbContext(DbContextOptions<RiderDbContext> options) : DbContext(options)
{
    public DbSet<Rider> Riders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rider>().ToTable("Riders");
        base.OnModelCreating(modelBuilder);
    }
}