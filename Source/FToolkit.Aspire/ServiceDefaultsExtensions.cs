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
    /// <typeparam name="TBuilder"><see cref="IHostApplicationBuilder"/>を実装するビルダーの型</typeparam>
    /// <param name="builder"><see cref="IHostApplicationBuilder"/>を実装するビルダー</param>
    public static void AddServiceDefaults<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        builder.ConfigureOpenTelemetry();
        builder.Services.ConfigureHttpClientDefaults(static x => x.AddStandardResilienceHandler());
    }

    static void ConfigureOpenTelemetry<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
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

    static void AddOpenTelemetryExporters<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        if (string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]))
        {
            return;
        }

        builder.Services.AddOpenTelemetry()
            .UseOtlpExporter();
    }
}
