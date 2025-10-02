namespace myRiderSharing.RiderApi.Application.Queries.DTOs;

public record GetRiderByIdQuery(int id) : IRequest<Rider>;
