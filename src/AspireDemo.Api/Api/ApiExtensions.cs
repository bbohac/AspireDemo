using AspireDemo.Api.Api.Weather;

namespace AspireDemo.Api.Api;

public static class ApiExtensions
{
    public static WebApplication MapApi(this WebApplication app)
    {
        var api = app.MapGroup("/api");
        var version1 = api.MapGroup("/v1").WithApiVersionSet(ApiVersions.Version1(app)).HasApiVersion(1);
        version1.MapWeatherEndpoints();

        return app;
    }
}
