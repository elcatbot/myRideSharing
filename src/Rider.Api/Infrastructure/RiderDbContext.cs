using Microsoft.EntityFrameworkCore;
using myRiderSharing.RiderApi.Application.Models;

namespace myRiderSharing.RiderApi.Infrastructure;

public class RiderDbContext(DbContextOptions<RiderDbContext> options) : DbContext(options)
{
    public DbSet<Rider> Riders { get; set; }
}