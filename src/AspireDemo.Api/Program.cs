using Asp.Versioning;
using AspireDemo.Api.Api;
using AspireDemo.Api.Api.Weather;
using AspireDemo.Api.Application.Weather;
using FluentValidation;
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

builder.Services.AddScoped<IForecastService, ForecastService>();
builder.Services.AddValidatorsFromAssemblyContaining<ForecastRequestValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapApi();

app.Run();
