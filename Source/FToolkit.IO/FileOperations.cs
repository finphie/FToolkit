using System.Security;
using Microsoft.Extensions.Logging;

namespace FToolkit.IO;

/// <summary>
/// ファイル操作を行うクラスです。
/// </summary>
public sealed partial class FileOperations : IFileOperations
{
    readonly ILogger _logger;

    /// <summary>
    /// <see cref="FileOperations"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <exception cref="ArgumentNullException">ロガーがnullです。</exception>
    public FileOperations(ILogger<FileOperations> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">パスがnullです。</exception>
    /// <exception cref="ArgumentException">パスが空文字か空白です。</exception>
    /// <exception cref="NotSupportedException">パスがファイル以外のデバイスを参照しています。</exception>
    /// <exception cref="IOException">I/Oエラーが発生しました。</exception>
    /// <exception cref="SecurityException">アクセス許可がありません。</exception>
    /// <exception cref="DirectoryNotFoundException">パスが無効です。</exception>
    /// <exception cref="UnauthorizedAccessException">オペレーティングシステムによってアクセスが拒否されました。</exception>
    /// <exception cref="PathTooLongException">パスまたはファイル名がシステム定義の最大長を超えています。</exception>
    public void Create(string filePath, ReadOnlySpan<byte> bytes)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        Creating(filePath);

        try
        {
            Write(filePath, bytes, FileMode.Create);
        }
        catch (Exception ex)
        {
            CouldNotCreateFile(filePath, ex);
            throw;
        }
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">パスがnullです。</exception>
    /// <exception cref="ArgumentException">パスが空文字か空白です。</exception>
    /// <exception cref="NotSupportedException">パスがファイル以外のデバイスを参照しています。</exception>
    /// <exception cref="IOException">I/Oエラーが発生しました。</exception>
    /// <exception cref="SecurityException">アクセス許可がありません。</exception>
    /// <exception cref="DirectoryNotFoundException">パスが無効です。</exception>
    /// <exception cref="UnauthorizedAccessException">オペレーティングシステムによってアクセスが拒否されました。</exception>
    /// <exception cref="PathTooLongException">パスまたはファイル名がシステム定義の最大長を超えています。</exception>
    public void Create(string filePath, ReadOnlyMemory<byte> bytes)
        => Create(filePath, bytes.Span);

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">パスがnullです。</exception>
    /// <exception cref="ArgumentException">パスが空文字か空白です。</exception>
    /// <exception cref="NotSupportedException">パスがファイル以外のデバイスを参照しています。</exception>
    /// <exception cref="IOException">I/Oエラーが発生しました。</exception>
    /// <exception cref="SecurityException">アクセス許可がありません。</exception>
    /// <exception cref="DirectoryNotFoundException">パスが無効です。</exception>
    /// <exception cref="UnauthorizedAccessException">オペレーティングシステムによってアクセスが拒否されました。</exception>
    /// <exception cref="PathTooLongException">パスまたはファイル名がシステム定義の最大長を超えています。</exception>
    public void Save(string filePath, ReadOnlySpan<byte> bytes)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        Saving(filePath);

        try
        {
            Write(filePath, bytes, FileMode.CreateNew);
        }
        catch (Exception ex)
        {
            CouldNotSaveFile(filePath, ex);
            throw;
        }
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">パスがnullです。</exception>
    /// <exception cref="ArgumentException">パスが空文字か空白です。</exception>
    /// <exception cref="NotSupportedException">パスがファイル以外のデバイスを参照しています。</exception>
    /// <exception cref="IOException">I/Oエラーが発生しました。</exception>
    /// <exception cref="SecurityException">アクセス許可がありません。</exception>
    /// <exception cref="DirectoryNotFoundException">パスが無効です。</exception>
    /// <exception cref="UnauthorizedAccessException">オペレーティングシステムによってアクセスが拒否されました。</exception>
    /// <exception cref="PathTooLongException">パスまたはファイル名がシステム定義の最大長を超えています。</exception>
    public void Save(string filePath, ReadOnlyMemory<byte> bytes)
        => Save(filePath, bytes.Span);

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">パスがnullです。</exception>
    /// <exception cref="ArgumentException">パスが空文字か空白です。</exception>
    /// <exception cref="NotSupportedException">パスがファイル以外のデバイスを参照しています。</exception>
    /// <exception cref="IOException">I/Oエラーが発生しました。</exception>
    /// <exception cref="SecurityException">アクセス許可がありません。</exception>
    /// <exception cref="DirectoryNotFoundException">パスが無効です。</exception>
    /// <exception cref="UnauthorizedAccessException">オペレーティングシステムによってアクセスが拒否されました。</exception>
    /// <exception cref="PathTooLongException">パスまたはファイル名がシステム定義の最大長を超えています。</exception>
    public void Delete(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        Deleting(filePath);

        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                CouldNotDeleteFile(filePath, ex);
                throw;
            }
        }
    }

    static void Write(string filePath, ReadOnlySpan<byte> bytes, FileMode mode)
    {
        using var handle = File.OpenHandle(filePath, mode, FileAccess.Write);
        RandomAccess.Write(handle, bytes, 0);
    }

    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Creating file: {filePath}")]
    partial void Creating(string filePath);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Saving file: {filePath}")]
    partial void Saving(string filePath);

    [LoggerMessage(EventId = 3, Level = LogLevel.Information, Message = "Deleting file: {filePath}")]
    partial void Deleting(string filePath);

    [LoggerMessage(EventId = 5001, Level = LogLevel.Warning, Message = "Could not create file: {filePath}")]
    partial void CouldNotCreateFile(string filePath, Exception ex);

    [LoggerMessage(EventId = 5002, Level = LogLevel.Warning, Message = "Could not save file: {filePath}")]
    partial void CouldNotSaveFile(string filePath, Exception ex);

    [LoggerMessage(EventId = 5003, Level = LogLevel.Warning, Message = "Could not delete file: {filePath}")]
    partial void CouldNotDeleteFile(string filePath, Exception ex);
}
