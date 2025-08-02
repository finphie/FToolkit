using System.Windows;
using FToolkit.Objects;
using Microsoft.Extensions.Logging;

namespace FToolkit.Views.Wpf;

/// <summary>
/// アプリケーションテーマを操作するクラスです。
/// </summary>
public sealed partial class ApplicationThemeOperations : IApplicationThemeOperations
{
    readonly ILogger<ApplicationThemeOperations> _logger;

    /// <summary>
    /// <see cref="ApplicationThemeOperations"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ログ記録のためのオブジェクト</param>
    public ApplicationThemeOperations(ILogger<ApplicationThemeOperations> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

#pragma warning disable WPF0001 // 種類は、評価の目的でのみ提供されています。将来の更新で変更または削除されることがあります。続行するには、この診断を非表示にします。
    /// <inheritdoc/>
    public ApplicationTheme Get()
    {
        LogGetting();
        return Application.Current.ThemeMode.ToApplicationTheme();
    }

    /// <inheritdoc/>
    public void Change(ApplicationTheme theme)
    {
        LogChanging();

        var newTheme = theme.ToWpfApplicationTheme();

        foreach (Window window in Application.Current.Windows)
        {
            if (window.ThemeMode == newTheme)
            {
                continue;
            }

            window.ThemeMode = newTheme;
        }
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Getting current application theme.")]
    partial void LogGetting();

    [LoggerMessage(Level = LogLevel.Information, Message = "Changing application theme.")]
    partial void LogChanging();
}
