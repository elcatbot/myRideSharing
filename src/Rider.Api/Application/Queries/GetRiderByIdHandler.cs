namespace myRiderSharing.RiderApi.Application.Queries;

public class GetRiderByIdHandler(IOptions<RiderConfigOptions> Options) : IRequestHandler<GetRiderByIdQuery, Rider>
{
    private readonly RiderConfigOptions options = Options.Value;

    public async Task<Rider> Handle(GetRiderByIdQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = new SqliteConnection(options.ConnectionString);
        connection.Open();
        // return await connection.QueryFirstAsync<Rider>(@"select SQLITE_VERSION() AS Version");
        return await connection.QueryFirstAsync<Rider>("SELECT * FROM Riders WHERE Id = @id", new { request.id });
    }
}
