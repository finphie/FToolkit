using FToolkit.CodeAnalysis.CSharp.Extensions;

namespace FToolkit.CodeAnalysis.CSharp;

/// <summary>
/// コンパイラメッセージを表すクラスです。
/// </summary>
/// <param name="Id">ID</param>
/// <param name="Severity">コンパイラメッセージのレベル</param>
/// <param name="TextRange">範囲</param>
/// <param name="Message">メッセージ</param>
public sealed record CompilerMessage(string Id, CompilerMessageSeverity Severity, TextPositionRange TextRange, string Message)
    : ISpanFormattable
{
    const int BufferSize = 256;

    /// <inheritdoc/>
    public override string ToString()
        => string.Create(null, stackalloc char[BufferSize], $"{TextRange.Start} {Enum.GetName(Severity)} {Id}: {Message}");

    /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
    public bool TryFormat(Span<char> destination, out int charsWritten)
    {
        if (!destination.TryWrite(null, $"{TextRange.Start} ", out charsWritten))
        {
            return false;
        }

        destination = destination[charsWritten..];

        if (!Severity.TryGetName(destination, out var tmpCharsWritten))
        {
            return false;
        }

        charsWritten += tmpCharsWritten;
        destination = destination[tmpCharsWritten..];

        if (!destination.TryWrite(null, $" {Id}: {Message}", out tmpCharsWritten))
        {
            return false;
        }

        charsWritten += tmpCharsWritten;
        return true;
    }

    /// <inheritdoc/>
    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
        => string.Create(formatProvider, stackalloc char[BufferSize], $"{TextRange.Start} {Enum.GetName(Severity)} {Id}: {Message}");

    /// <inheritdoc/>
    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => TryFormat(destination, out charsWritten);
}
