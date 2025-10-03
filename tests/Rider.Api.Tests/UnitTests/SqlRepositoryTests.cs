using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using myRiderSharing.RiderApi.Infrastructure;
using myRiderSharing.RiderApi.Application.Models;

public class SqlRepositoryTest
{
    [Fact]
    public async Task AddAsync_ShouldAddRiderToDbSet()
    {
        // Arrange
        var rider = new Rider { Id = 1, FullName = "Test Rider" };
        var mockSet = new Mock<DbSet<Rider>>();
        var mockContext = new Mock<RiderDbContext>();
        mockContext.Setup(c => c.Riders).Returns(mockSet.Object);
        mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

        var repository = new SqlRepository(mockContext.Object);

        // Act
        await repository.AddAsync(rider);
        

        // Assert
        mockSet.Verify(s => s.AddAsync(rider, default), Times.Once);
    }

    // [Fact]
    // public async Task GetByIdAsync_ReturnsRider_WhenRiderExists()
    // {
    //     // Arrange
    //     var riderId = 1;
    //     var rider = new Rider { Id = riderId, FullName = "Test Rider" };
    //     var riders = new List<Rider> { rider }.AsQueryable();

    //     var dbSetMock = new Mock<DbSet<Rider>>();
    //     dbSetMock.As<IQueryable<Rider>>().Setup(m => m.Provider).Returns(riders.Provider);
    //     dbSetMock.As<IQueryable<Rider>>().Setup(m => m.Expression).Returns(riders.Expression);
    //     dbSetMock.As<IQueryable<Rider>>().Setup(m => m.ElementType).Returns(riders.ElementType);
    //     dbSetMock.As<IQueryable<Rider>>().Setup(m => m.GetEnumerator()).Returns(riders.GetEnumerator());

    //     dbSetMock.Setup(m => m.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Rider, bool>>>(), default))
    //         .ReturnsAsync(rider);

    //     var contextMock = new Mock<RiderDbContext>();
    //     contextMock.Setup(c => c.Riders).Returns(dbSetMock.Object);

    //     var repo = new SqlRepository(contextMock.Object);

    //     // Act
    //     var result = await repo.GetByIdAsync(riderId);

    //     // Assert
    //     Assert.NotNull(result);
    //     Assert.Equal(riderId, result.Id);
    //     Assert.Equal("Test Rider", result.FullName);
    // }

    // [Fact]
    // public async Task GetByIdAsync_ReturnsNull_WhenRiderDoesNotExist()
    // {
    //     // Arrange
    //     var riders = new List<Rider>().AsQueryable();

    //     var dbSetMock = new Mock<DbSet<Rider>>();
    //     dbSetMock.As<IQueryable<Rider>>().Setup(m => m.Provider).Returns(riders.Provider);
    //     dbSetMock.As<IQueryable<Rider>>().Setup(m => m.Expression).Returns(riders.Expression);
    //     dbSetMock.As<IQueryable<Rider>>().Setup(m => m.ElementType).Returns(riders.ElementType);
    //     dbSetMock.As<IQueryable<Rider>>().Setup(m => m.GetEnumerator()).Returns(riders.GetEnumerator());

    //     dbSetMock.Setup(m => m.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Rider, bool>>>(), default))
    //         .ReturnsAsync((Rider)null);

    //     var contextMock = new Mock<RiderDbContext>();
    //     contextMock.Setup(c => c.Riders).Returns(dbSetMock.Object);

    //     var repo = new SqlRepository(contextMock.Object);

    //     // Act & Assert
    //     await Assert.ThrowsAsync<System.NullReferenceException>(async () =>
    //     {
    //         await repo.GetByIdAsync(99);
    //     });
    // }
}