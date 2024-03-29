﻿using System.Diagnostics.CodeAnalysis;

namespace FToolkit.Helpers.GitHub;

/// <summary>
/// GitHub Actions関連のコマンドです。
/// </summary>
public static class GitHubActionsCommand
{
    /// <summary>
    /// 指定されたタイトルのグループを開始します。
    /// </summary>
    /// <param name="title">タイトル</param>
    /// <exception cref="ArgumentNullException"><paramref name="title"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="title"/>が空です。</exception>
    public static void GroupStart(string title)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        Console.WriteLine($"::group::{title}");
    }

    /// <summary>
    /// グループを終了します。
    /// </summary>
    [SuppressMessage("Globalization", "CA1303:ローカライズされるパラメーターとしてリテラルを渡さない", Justification = "ローカライズ対象の文字列ではないため。")]
    public static void GroupEnd() => Console.WriteLine("::endgroup::");
}
