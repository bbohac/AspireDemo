using Asp.Versioning;
using Asp.Versioning.Builder;

namespace AspireDemo.Api.Api;

public static class ApiVersions
{
    public static ApiVersionSet Version1(WebApplication app) =>
        app.NewApiVersionSet("v1").HasApiVersion(new ApiVersion(1)).Build();
}
