using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using FToolkit.Objects;
using FToolkit.ViewModels.Objects;
using Microsoft.Extensions.Localization;
using ObservableCollections;

namespace FToolkit.ViewModels;

/// <summary>
/// 設定ViewのViewModel基底クラスです。
/// </summary>
public abstract partial class SettingsViewModelBase : ViewModelBase, ITransientViewModel, IDisposable
{
    readonly IStringLocalizer<SettingsViewModelBase> _localizer;

    readonly ObservableList<ApplicationThemeView> _applicationThemes;

    bool _disposedValue;

    /// <summary>
    /// <see cref="SettingsViewModelBase"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    protected SettingsViewModelBase()
    {
        _localizer = Ioc.Default.GetRequiredService<IStringLocalizer<SettingsViewModelBase>>();

        ApplicationThemeHeader = _localizer["App theme"];
        ApplicationThemeDescription = _localizer["Select which app theme to display"];

        _applicationThemes =
        [
            new(_localizer["Use system setting"], ApplicationTheme.System),
            new(_localizer["Light"], ApplicationTheme.Light),
            new(_localizer["Dark"], ApplicationTheme.Dark)
        ];
        ApplicationThemesView = _applicationThemes.ToNotifyCollectionChangedSlim(SynchronizationContextCollectionEventDispatcher.Current);
        SelectedTheme = _applicationThemes.Single(x => x.Type == SettingsManager.Value.Theme);
    }

    /// <summary>
    /// アプリケーションバージョン
    /// </summary>
    public static string ApplicationVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;

    /// <summary>
    /// アプリケーションテーマのヘッダー文字列
    /// </summary>
    [ObservableProperty]
    public partial string ApplicationThemeHeader { get; private set; }

    /// <summary>
    /// アプリケーションテーマの説明文字列
    /// </summary>
    [ObservableProperty]
    public partial string ApplicationThemeDescription { get; private set; }

    /// <summary>
    /// 選択されているアプリケーションテーマ
    /// </summary>
    [ObservableProperty]
    public partial ApplicationThemeView SelectedTheme { get; private set; }

    /// <summary>
    /// アプリケーションテーマのリスト
    /// </summary>
    public NotifyCollectionChangedSynchronizedViewList<ApplicationThemeView> ApplicationThemesView { get; }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// リソースを解放します。
    /// </summary>
    /// <param name="disposing"><see langword="true"/>の場合はマネージドリソースを解放します。 </param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue)
        {
            return;
        }

        if (disposing)
        {
            ApplicationThemesView.Dispose();
        }

        _disposedValue = true;
    }

    partial void OnSelectedThemeChanged(ApplicationThemeView value)
        => SettingsManager.Notify(value.Type);

    [RelayCommand]
    void ChangeApplicationTheme(ApplicationThemeView theme)
        => SelectedTheme = theme;
}
