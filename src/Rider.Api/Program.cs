
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Configuration.GetSection(nameof(RiderConfigOptions)).Get<RiderConfigOptions>();

builder.Services.AddDbContext<RiderDbContext>(o => o.UseSqlite(builder.Configuration["RiderSettingOptions:ConnectionString"]));

builder.Services.AddTransient<IRiderRepository, SqlRepository>();

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

app.InitDbContextMigration();

app.Run();

