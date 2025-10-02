using myRiderSharing.RiderApi.Application.Queries;

namespace myRiderSharing.RiderApi.Apis;

public static class RiderApi
{
    public static RouteGroupBuilder MapRiderApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/rider");

        api.MapGet("/{id:int}", GetRiderProfileAsync);
        api.MapGet("/{id:int}/trips", GetRiderTripHistoryAsync); // Proxy from Trip Service
        api.MapPost("/", CreateRiderProfile);
        api.MapPut("/", UpdateRiderProfile);

        return api;
    }

    private static async Task<Results<Ok<RiderDTO>, NotFound>> GetRiderProfileAsync([AsParameters] RiderParamServices services, [AsParameters] GetRiderByIdQuery query)
    {
        var queryResult = await services.Mediator.Send(query);

        return queryResult != null
            ? TypedResults.Ok(RiderDTO.FromEntityToDTO(queryResult))
            : TypedResults.NotFound();
    }

    private static async Task GetRiderTripHistoryAsync(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<Results<Created, BadRequest, ProblemHttpResult>> CreateRiderProfile([AsParameters] RiderParamServices services, CreateRiderProfileCommand command)
    {
        var commandResult = await services.Mediator.Send(command);
        if (!commandResult)
        {
            return TypedResults.Problem(detail: "Rider profile failed to create", statusCode: 500);
        }
        return TypedResults.Created();
    }

    private static async Task<Results<NoContent, ProblemHttpResult>> UpdateRiderProfile([AsParameters] RiderParamServices services, UpdateRiderProfileCommand command)
    {
        var commandResult = await services.Mediator.Send(command);
        if (!commandResult)
        {
            return TypedResults.Problem(detail: "Rider profile failed to update", statusCode: 500);
        }
        return TypedResults.NoContent();
    }
}