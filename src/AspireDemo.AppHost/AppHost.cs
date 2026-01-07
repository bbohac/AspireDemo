var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").WithDataVolume();

var redis = builder.AddRedis("redis").WithDataVolume();

var api = builder
    .AddProject<Projects.AspireDemo_Api>("api")
    .WithExternalHttpEndpoints()
    .WithUrls(context =>
    {
        foreach (var url in context.Urls)
        {
            url.DisplayLocation = UrlDisplayLocation.DetailsOnly;
        }

        context.Urls.Add(
            new()
            {
                Url = "/scalar",
                DisplayText = "API Reference",
                Endpoint = context.GetEndpoint("https"),
            }
        );
    })
    .WithReference(postgres)
    .WaitFor(postgres)
    .WithReference(redis)
    .WaitFor(redis);

var frontend = builder
    .AddViteApp("frontend", "../AspireDemo.Frontend")
    .WithEndpoint("http", e => e.Port = 5173)
    .WithUrl("", "Aspire Demo")
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();
