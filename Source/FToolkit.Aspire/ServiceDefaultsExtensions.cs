using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace FToolkit.Aspire;

/// <summary>
/// サービスの既定構成を追加します。
/// </summary>
public static class ServiceDefaultsExtensions
{
    /// <summary>
    /// サービスの既定構成を<see cref="IHostApplicationBuilder"/>に追加します。
    /// </summary>
    /// <param name="builder"><see cref="IHostApplicationBuilder"/>を実装するビルダー</param>
    public static void AddServiceDefaults(this IHostApplicationBuilder builder)
    {
        builder.ConfigureOpenTelemetry();
        builder.Services.ConfigureHttpClientDefaults(static x => x.AddStandardResilienceHandler());
    }

    static void ConfigureOpenTelemetry(this IHostApplicationBuilder builder)
    {
        builder.Logging.AddOpenTelemetry(static options =>
        {
            options.IncludeFormattedMessage = true;
            options.IncludeScopes = true;
        });

        builder.Services.AddOpenTelemetry()
            .WithMetrics(static builder =>
            {
                builder.AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation();
            });

        builder.AddOpenTelemetryExporters();
    }

    static void AddOpenTelemetryExporters(this IHostApplicationBuilder builder)
    {
        if (string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]))
        {
            return;
        }

        builder.Services.AddOpenTelemetry()
            .UseOtlpExporter();
    }
}
