using Npgsql;

namespace myRiderSharing.RiderApi.Application.Queries;

public class GetRiderByIdHandler(IOptions<RiderConfigOptions> Options) : IRequestHandler<GetRiderByIdQuery, Rider>
{
    private readonly RiderConfigOptions options = Options.Value;

    public async Task<Rider> Handle(GetRiderByIdQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = new NpgsqlConnection(options.ConnectionString);
        connection.Open();
        return (await connection.QueryFirstOrDefaultAsync<Rider>(
                @"SELECT 
                    r.id, r.user_id as userid, r.full_name as fullname, r.email, r.phone_number as phonenumber, r.rating, r.created_at as createdat, r.updated_at as updatedat
                    FROM riders r
                    WHERE r.id = @id"
                , new { request.id }
            ))!;
    }
}
