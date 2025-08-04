using Microsoft.Extensions.Options;

namespace FToolkit.Options;

/// <summary>
/// 再読み込み可能なオプション値を取得するクラスです。
/// </summary>
/// <typeparam name="T">オプション値の種類</typeparam>
public class ReloadableOptions<T> : IReloadableOptions<T>
    where T : class, IEquatable<T>
{
    readonly IOptionsMonitor<T> _options;

    /// <summary>
    /// <see cref="ReloadableOptions{T}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="options">オプション値の取得を行うオブジェクト</param>
    public ReloadableOptions(IOptionsMonitor<T> options)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options;
    }

    /// <inheritdoc/>
    public T Value => _options.CurrentValue;
}
