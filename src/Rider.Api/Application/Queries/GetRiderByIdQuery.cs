namespace myRiderSharing.RiderApi.Application.Queries;

public record GetRiderByIdQuery(int id) : IRequest<Rider>;
