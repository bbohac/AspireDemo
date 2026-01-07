using Asp.Versioning;
using AspireDemo.Api.Api;
using AspireDemo.Api.Api.Weather;
using AspireDemo.Application.Forecast;
using AspireDemo.Application.ForecastHistory;
using AspireDemo.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services.AddOpenApi()
    .AddProblemDetails()
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.AddRedisClient("redis");
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("redis")
);

builder.Services.AddScoped<IForecastService, ForecastService>();
builder.Services.Decorate<IForecastService, ForecastCachingDecorator>();

//builder.Services.AddScoped<ForecastService>();
//builder.Services.AddScoped<IForecastService>(sp =>
//{
//    var inner = sp.GetRequiredService<ForecastService>();
//    var cache = sp.GetRequiredService<IDistributedCache>();

//    return new ForecastCachingDecorator(inner, cache);
//});

builder.Services.AddScoped<IForecastHistoryService, ForecastHistoryService>();
builder.Services.AddValidatorsFromAssemblyContaining<ForecastRequestValidator>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapApi();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
