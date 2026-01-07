using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace AspireDemo.ServiceDefaults;

public static class ServiceDefaultsExtensions
{
    public static void AddServiceDefaults(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks();
        builder
            .Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation();
                metrics.AddHttpClientInstrumentation();
                metrics.AddRuntimeInstrumentation();
                metrics.AddMeter("*");
            })
            .WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation();
                tracing.AddHttpClientInstrumentation();
                tracing.AddSource("*");
            })
            .UseOtlpExporter();
    }
}
