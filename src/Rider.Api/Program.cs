using Microsoft.EntityFrameworkCore;
using myRiderSharing.RiderApi.Apis;
using myRiderSharing.RiderApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<RiderDbContext>(o => o.UseInMemoryDatabase("RiderDB"));

builder.Services.AddTransient<IRiderRepository, PostgreSqlRepository>();

builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblyContaining(typeof(Program)));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapRiderApiV1();

app.Run();

