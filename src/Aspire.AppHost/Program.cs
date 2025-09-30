using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Analytics_Api>("Analytics");

builder.Build().Run();
